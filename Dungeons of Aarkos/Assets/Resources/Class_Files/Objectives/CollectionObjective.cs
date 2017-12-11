using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    public class CollectionObjective : IQuestObjective
    {

        private string title;
        private string description;
        private bool isComplete;
        private bool isBonus;
        private string verb;
        private int collectionAmount;
        private int currentAmount;
        private GameObject itemToCollect;

        public CollectionObjective(string titleVerb, int totalAmount, GameObject item, string descrip, bool  bonus)
        {
            title = titleVerb + " " + totalAmount + " " + item.name;
            verb = titleVerb;
            description = descrip;
            itemToCollect = item;
            collectionAmount = totalAmount;
            currentAmount = 0;
            isBonus = bonus;
            CheckProgress();
        }

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

        public int CurrentAmount
        {
            get
            {
                return currentAmount;
            }
        }

        public int CollectionAmount
        {
            get
            {
                return collectionAmount;
            }
        }

        public GameObject ItemToCollect
        {
            get
            {
                return itemToCollect;
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
            if (currentAmount >= collectionAmount)
                isComplete = true;
            else
                isComplete = false;
        }

        public void UpdateProgress()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return currentAmount + "/" + collectionAmount + " " + itemToCollect.name + " " + verb + "ed!";
        }
    }
}

