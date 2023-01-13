using UnityEngine;

public class GameController : MonoBehaviour{
    private static readonly int FPS = 60;

    private static GameController _instance;

    public static GameController GetInstance(){
        return _instance;
    }

    [SerializeField] private Texture2D targetCursorTexture;
    [SerializeField] private Texture2D cursorTexture;

    private void Start(){
        _instance = this;
        //SetCursor(cursorTexture, false);
        SetTargetCursor();
        Application.targetFrameRate = FPS;
    }

    private void Update(){
        
    }

    public void SetTargetCursor(){
        SetCursor(targetCursorTexture, true);
    }

    public void SetPixelCursor(){
        SetCursor(cursorTexture, false);
    }

    private void SetCursor(Texture2D texture, bool center){
        if (center){
            Cursor.SetCursor(texture, new Vector2(texture.width / 2f, texture.height / 2f), CursorMode.Auto);
            return;
        }

        Cursor.SetCursor(texture, Vector2.zero, CursorMode.Auto);
    }
}