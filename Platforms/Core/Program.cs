using System;

namespace Core {
    public static class Program {
        [STAThread]
        static void Main() {
            using(var game = new GameRoot())
            game.Run();
        }
    }
}