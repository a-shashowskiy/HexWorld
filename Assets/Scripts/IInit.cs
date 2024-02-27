namespace HexWorld
{
    internal interface IInitHex
    {
        public void Init(ResourceType rt, int gainedRes, HexSettings hexZone , HexZoneOpenValue zoneOpenValue);
    }
}