﻿using AutoMapper;
using LearningApp.Application.DataTransferObjects.TopicDTO;
using LearningApp.Application.Enums;
using LearningApp.Application.Exceptions;
using LearningApp.Application.Wrappers;
using LearningApp.Data.Entities.ProblemEntity;
using LearningApp.Data.IRepositories.ITopicRepository;
using MediatR;

namespace LearningApp.Web.Modules.Topics
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;

        public TopicService(ITopicRepository topicRepository, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<TopicResponseDTO>>> GetAllTopics()
        {
            var topics = await _topicRepository.GetAllTopics();

            if (topics == null)
                return new Response<List<TopicResponseDTO>>(true, null, GeneralMessages.TopicsNotAdded);

            foreach (var topic in topics)
                topic.TotalLessons = topic.Problem.GroupBy(x => x.LessonNumber).Count();

            var response = _mapper.Map<List<TopicResponseDTO>>(topics);
            return new Response<List<TopicResponseDTO>>(true, response, GeneralMessages.RecordFetched);
        }

        public async Task<Response<TopicResponseDTO>> GetTopicById(Guid topicId)
        {
            var topic = await _topicRepository.GetTopicById(topicId);

            if (topic == null)
                throw new KeyNotFoundException(GeneralMessages.RecordNotFound);

            topic.TotalLessons = topic.Problem.GroupBy(x => x.LessonNumber).Count();

            var response = _mapper.Map<TopicResponseDTO>(topic);
            return new Response<TopicResponseDTO>(true, response, GeneralMessages.RecordFetched);
        }

        public async Task<Response<TopicResponseDTO>> CreateTopic(TopicRequestDTO request)
        {
            // check if topic with this name already exists
            var topic = await _topicRepository.GetTopicByName(request.TopicName);
            if (topic != null)
                throw new BadRequestException(GeneralMessages.TopicExists);

            Topic newTopic = new()
            {
                TopicName = request.TopicName,
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            await _topicRepository.CreateTopic(newTopic);
            await _topicRepository.SaveChanges();

            return new Response<TopicResponseDTO>(true, null, GeneralMessages.RecordAdded);
        }

        public async Task<Response<TopicResponseDTO>> UpdateTopic(Guid topicId, TopicRequestDTO request)
        {
            var topic = await _topicRepository.GetTopicById(topicId);
            if (topic == null)
                throw new KeyNotFoundException(GeneralMessages.RecordNotFound);

            // check if topic with this name already exists
            var topicWithName = await _topicRepository.GetTopicByName(request.TopicName);
            if (topicWithName != null)
                throw new BadRequestException(GeneralMessages.TopicExists);


            topic.TopicName = request.TopicName;
            topic.UpdatedAt = DateTime.Now;

            await _topicRepository.SaveChanges();

            return new Response<TopicResponseDTO>(true, null, GeneralMessages.RecordUpdated);
        }

        public async Task<Response<bool>> DeleteTopic(Guid topicId)
        {
            var topic = await _topicRepository.GetTopicById(topicId);
            if (topic == null)
                throw new KeyNotFoundException(GeneralMessages.RecordNotFound);

            topic.UpdatedAt = DateTime.Now;
            topic.DeletedAt = DateTime.Now;
            topic.IsActive = false;

            await _topicRepository.SaveChanges();

            return new Response<bool>(true, true, GeneralMessages.RecordDeleted);

        }
    }
}
