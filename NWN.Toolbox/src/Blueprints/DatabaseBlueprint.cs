using Anvil.API;

namespace Jorteck.Toolbox
{
  internal sealed class DatabaseBlueprint : IBlueprint
  {
    private readonly BlueprintModel dbModel;

    public string Name => dbModel.Name;

    public string Category => dbModel.Category;
    public float? CR => dbModel.CR;
    public string Faction => dbModel.Faction;

    public string FullName => Category + "/" + Name;

    public BlueprintObjectType ObjectType => dbModel.Type;

    public DatabaseBlueprint(BlueprintModel dbModel)
    {
      this.dbModel = dbModel;
    }

    public NwObject Create(Location location)
    {
      NwGameObject gameObject = ObjectType switch
      {
        BlueprintObjectType.Creature => NwCreature.Deserialize(dbModel.BlueprintData),
        BlueprintObjectType.Door => NwDoor.Deserialize(dbModel.BlueprintData),
        BlueprintObjectType.Encounter => NwEncounter.Deserialize(dbModel.BlueprintData),
        BlueprintObjectType.Item => NwItem.Deserialize(dbModel.BlueprintData),
        BlueprintObjectType.Placeable => NwPlaceable.Deserialize(dbModel.BlueprintData),
        BlueprintObjectType.Sound => NwSound.Deserialize(dbModel.BlueprintData),
        BlueprintObjectType.Store => NwStore.Deserialize(dbModel.BlueprintData),
        BlueprintObjectType.Trigger => NwTrigger.Deserialize(dbModel.BlueprintData),
        BlueprintObjectType.Waypoint => NwWaypoint.Deserialize(dbModel.BlueprintData),
        _ => null,
      };

      if (gameObject != null)
      {
        gameObject.Location = location;
      }

      return gameObject;
    }
  }
}
