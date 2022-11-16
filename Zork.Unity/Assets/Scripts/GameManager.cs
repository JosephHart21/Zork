using UnityEngine;
using Zork.Common;
using Newtonsoft.Json;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI LocationText;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI MovesText;

    [SerializeField] private UnityInputService InputService;
    [SerializeField] private UnityOutputService OutputService;

    private void Awake()
    {
        TextAsset gameJson = Resources.Load<TextAsset>("GameJson");
        _game = JsonConvert.DeserializeObject<Game>(gameJson.text);
        _game.Run(InputService,OutputService);
    }

    private void Start()
    {
        InputService.SetFocus();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            InputService.ProcessInput();
            InputService.SetFocus();
        }
        if (_game.IsRunning == false)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    private Game _game;

}