using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace QuestSystem
{
    public class LocationObjective : IQuestObjective
    {
        private string title;
        private string description;
        private bool isComplete;
        private bool isBonus;
        private Location targetLocation;

        public string Description
        {
            get
            {
                return description;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }
        }

        public bool IsComplete
        {
            get
            {
                return isComplete;
            }
        }

        public bool IsBonus
        {
            get
            {
                return isBonus;
            }
        }

        public void CheckProgress()
        {
            if (Player.GetLocation.Compare(targetLocation))
                isComplete = true;
            else
                isComplete = false;
        }

        public void UpdateProgress()
        {
            throw new NotImplementedException();
        }
    }
}

