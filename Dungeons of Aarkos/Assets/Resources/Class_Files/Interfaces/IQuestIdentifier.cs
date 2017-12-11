using System.Collections;
using UnityEngine;

public interface IQuestIdentifier
{
    int SourceID { get; }
    int ChainQuestID { get; }
    int ID { get; }
}
