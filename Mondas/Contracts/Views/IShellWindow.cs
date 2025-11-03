using System.Windows.Forms;

namespace Mondas.Contracts.Views
{
    public interface IShellWindow
    {

        Panel GetNavigationFrame();

        void ShowWindow();

        void CloseWindow();
    }
}
