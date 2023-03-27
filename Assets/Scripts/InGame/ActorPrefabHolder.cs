using System.Collections.Generic;
using UnityEngine;

public enum PrefabType
{
    HachikoPlayer1,
    Building109Player1,
    MoyaiPlayer1,
    AbemaPlayer1,
    HachikoPlayer2,
    Building109Player2,
    MoyaiPlayer2,
    AbemaPlayer2,
}

public class ActorPrefabHolder : MonoBehaviour
{
    [System.Serializable]
    public struct PrefabData
    {
        [SerializeField] PrefabType _type;
        [SerializeField] GameObject _prefab;

        public PrefabType Type => _type;
        public GameObject Prefab => _prefab;
    }

    [Header("�L�����N�^�[��Prefab")]
    [SerializeField] PrefabData[] _actorPrefabs;

    Dictionary<PrefabType, GameObject> _dic = new(8);

    void Awake()
    {
        foreach (PrefabData prefabData in _actorPrefabs)
        {
            _dic.Add(prefabData.Type, prefabData.Prefab);
        }
    }

    /// <summary>
    /// �v���C���[�̔ԍ���ID�ɑΉ������L�����N�^�[�̃C���X�^���X�𐶐����ĕԂ�
    /// </summary>
    /// <param name="playerNumber">�v���C���[�̔ԍ� 1or2</param>
    /// <param name="actorId">�v���C���[���I�������L�����N�^�[��ID</param>
    /// <returns>���������C���X�^���X</returns>
    public GameObject GetActorPrefab(int playerNumber, int actorId)
    {
        if (playerNumber == 1)
        {
            switch (actorId)
            {
                case 0: return Instantiate(_dic[PrefabType.HachikoPlayer1]);
                case 1: return Instantiate(_dic[PrefabType.Building109Player1]);
                case 2: return Instantiate(_dic[PrefabType.MoyaiPlayer1]);
                case 3: return Instantiate(_dic[PrefabType.AbemaPlayer1]);
                default: return null;
            }
        }
        else if (playerNumber == 2)
        {
            switch (actorId)
            {
                case 0: return Instantiate(_dic[PrefabType.HachikoPlayer2]);
                case 1: return Instantiate(_dic[PrefabType.Building109Player2]);
                case 2: return Instantiate(_dic[PrefabType.MoyaiPlayer2]);
                case 3: return Instantiate(_dic[PrefabType.AbemaPlayer2]);
                default: return null;
            }
        }
        else
        {
            return null;
        }
    }
}
