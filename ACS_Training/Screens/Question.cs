using System;
using System.Collections.Generic;
using System.Linq;
using ACS_Training.Classes;

namespace ACS_Training.Screens
{
    internal class Question
    {
        private Topic topic;

        public Question(Topic topic)
        {
            this.topic = topic;
        }

        public string questionDescription { get; set; }
        public string questionText { get; set; }
        public List<Option> options { get; set; }
        public string correctAnswer { get; set; }

        public Question getQuestion()
        {
            var random = new Random();
            List<Option> options = new List<Option>();

            SubTopic correctAnswerSubTopic = topic.subTopics[random.Next(topic.subTopics.Count)];
            this.correctAnswer = correctAnswerSubTopic.name;
            Option correctOption = new Option() { optionText = correctAnswerSubTopic.name, status = true };
            options.Add(correctOption);
            this.questionText = correctAnswerSubTopic.points[random.Next(correctAnswerSubTopic.points.Count)];
            List<SubTopic> copyOfSubTopicsList = new List<SubTopic>();
            topic.subTopics.ForEach(subtopic => copyOfSubTopicsList.Add(subtopic));
            copyOfSubTopicsList.Remove(correctAnswerSubTopic);
            do
            {
                SubTopic incorrectOptionSubtopic = copyOfSubTopicsList[random.Next(copyOfSubTopicsList.Count)];
                Option incorrectOption = new Option { optionText = incorrectOptionSubtopic.name, status = false };
                options.Add(incorrectOption);
                copyOfSubTopicsList.Remove(incorrectOptionSubtopic);

            } while (options.Count < 3);
            this.options = options.OrderBy(option => Guid.NewGuid()).ToList();
            this.questionDescription = "For the given statememt, \nPlease choose the subtopic it belongs to ";
            return this;

        }
    }
}