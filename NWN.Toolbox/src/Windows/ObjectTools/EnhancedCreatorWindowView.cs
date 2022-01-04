using System.Collections.Generic;
using Anvil.API;

namespace Jorteck.Toolbox
{
  public sealed class EnhancedCreatorWindowView : WindowView<EnhancedCreatorWindowView>
  {
    public override string Id => "creator.enhanced";
    public override string Title => "Creator: Enhanced";
    public override NuiWindow WindowTemplate { get; }

    public override IWindowController CreateDefaultController(NwPlayer player)
    {
      return CreateController<EnhancedCreatorWindowController>(player);
    }

    // Sub-views
    public readonly NuiGroup CreatorListContainer = new NuiGroup
    {
      Id = "creator_list",
    };

    // Value Binds
    public readonly NuiBind<string> Search = new NuiBind<string>("search_val");
    public readonly NuiBind<int> BlueprintType = new NuiBind<int>("type_val");
    public readonly NuiBind<string> SelectedBlueprint = new NuiBind<string>("selected_blue");

    // Buttons
    public readonly NuiButtonImage SearchButton;
    public readonly NuiButton CreateButton;

    public EnhancedCreatorWindowView()
    {
      SearchButton = new NuiButtonImage("isk_search")
      {
        Id = "btn_search",
        Aspect = 1f,
      };

      CreateButton = new NuiButton("Create")
      {
        Id = "btn_create",
        Width = 300f,
      };

      NuiColumn root = new NuiColumn
      {
        Children = new List<NuiElement>
        {
          new NuiRow
          {
            Height = 40f,
            Children = new List<NuiElement>
            {
              NuiUtils.CreateComboForEnum<BlueprintObjectType>(BlueprintType),
              new NuiTextEdit("Search...", Search, 255, false),
              SearchButton,
            },
          },
          new NuiLabel(SelectedBlueprint)
          {
            Height = 20f,
          },
          CreatorListContainer,
          new NuiRow
          {
            Height = 40f,
            Children = new List<NuiElement>
            {
              new NuiSpacer(),
              CreateButton,
              new NuiSpacer(),
            },
          },
        },
      };

      WindowTemplate = new NuiWindow(root, Title)
      {
        Geometry = new NuiRect(500f, 100f, 500f, 720f),
      };
    }
  }
}
