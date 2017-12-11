using System.Collections;
using UnityEngine;

public interface IQuestObjective
{
	string Title { get; }
    string Description { get; }
    bool IsComplete { get;}
    bool IsBonus { get; }
    void UpdateProgress();
    void CheckProgress();
}
