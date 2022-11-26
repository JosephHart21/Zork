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
        LocationText.text = _game.Player.CurrentRoom.Name;
        _game.Player.LocationChanged += Player_LocationChanged;
        _game.Player.ScoreChanged += Player_ScoreChanged;
        _game.Player.MoveChanged += Player_MoveChanged;
    }

    private void Player_LocationChanged(object sender, Room location)
    {
        LocationText.text = location.Name;
    }
    private void Player_ScoreChanged(object sender, int score)
    {
        ScoreText.text = "Score: " + score.ToString();
    }
    private void Player_MoveChanged(object sender, int moves)
    {
        MovesText.text = "Moves: " + moves.ToString();
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