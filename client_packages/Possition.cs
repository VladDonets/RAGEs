using RAGE;
using RAGE.Elements;

public class Coordinates : Events.Script
{
    public Coordinates()
    {
        // событие тика, чтобы обновить координаты игрока
        Events.Tick += OnTick;
    }

    private void OnTick(List<Events.TickNametagData> nametags)
    {
        Player player = Player.LocalPlayer;

        if (player == null || !player.Exists())
        {
            return;
        }

        // получение текущей позиции игрока
        Vector3 position = player.Position;

        // перевод в строку
        string coords = string.Format("X: {0:F2}, Y: {1:F2}, Z: {2:F2}", position.X, position.Y, position.Z);

        // отображение координат на экране игрока
        RAGE.Ui.Text.Draw(coords, new Vector2(0.5f, 0.05f), RAGE.Ui.Text.Alignment.Center, 0, 1.0f, false);
    }
}