using System.Collections.Generic;
namespace QuestSystem
{
	public class Quest
	{
        public Quest()
        {

        }

        private List<IQuestObjective> objectives;


        private bool IsComplete()
        {
            for(int i = 0; i < objectives.Count; i++)
            {
                if(objectives[i].IsComplete == false && objectives[i].IsBonus == false)
                {
                    return false;
                }
            }

            return true;
        }
	}
}
	
