using RAGE;
using RAGE.Elements;

public class Coordinates : Events.Script
{
    public Coordinates()
    {
        // ������� ����, ����� �������� ���������� ������
        Events.Tick += OnTick;
    }

    private void OnTick(List<Events.TickNametagData> nametags)
    {
        Player player = Player.LocalPlayer;

        if (player == null || !player.Exists())
        {
            return;
        }

        // ��������� ������� ������� ������
        Vector3 position = player.Position;

        // ������� � ������
        string coords = string.Format("X: {0:F2}, Y: {1:F2}, Z: {2:F2}", position.X, position.Y, position.Z);

        // ����������� ��������� �� ������ ������
        RAGE.Ui.Text.Draw(coords, new Vector2(0.5f, 0.05f), RAGE.Ui.Text.Alignment.Center, 0, 1.0f, false);
    }
}