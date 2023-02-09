using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class StatisticComponent : MonoBehaviour
{
	[SerializeField] private GameObject _cube;
	[SerializeField] private TextMeshProUGUI _label;

	private Dictionary<int, int> _dictOfcubes;
	private CubeHunterComponent _component;

	private void Start()
	{
		_component = _cube.GetComponent<CubeHunterComponent>();
	}

	private void Update()
	{
		GetRefreshedList();
	}

	private void GetRefreshedList()
	{
		_dictOfcubes = _component.ReturnDictOfCubes();

		var sortedDict = from i in _dictOfcubes orderby i.Value descending select i;

		Dictionary<int, int> dict = sortedDict.ToDictionary(x => x.Key, x => x.Value);

		WriteOnLabel(dict);

	}

	private void WriteOnLabel(Dictionary<int, int> sortedDict)
	{
		_label.text = "";

		int number = 0;
		foreach (var item in sortedDict)
		{
			number++;
			if (number >= 6)
			{
				break;
			}
			_label.text += $"{number}. Cube #{item.Key}, Score: {item.Value}\n";
		}
	}


}
