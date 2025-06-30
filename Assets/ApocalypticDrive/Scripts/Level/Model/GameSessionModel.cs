using System.Collections.Generic;

namespace MeShineFactory.ApocalypticDrive.Level.Model
{
    public class GameSessionModel
    {
        public List<IEnemy> Enemies { get; set; } = new();
        public PropagationField<float> Health { get; private set; } = new();
    }
}
