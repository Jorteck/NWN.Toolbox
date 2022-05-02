using System.Collections.Generic;
using Anvil.API;

namespace Jorteck.Toolbox.Core
{
  public sealed class ObjectSelectionListView
  {
    public readonly string ObjectRowId = "obj_rows";

    // Value Binds
    public readonly NuiBind<string> Search = new NuiBind<string>("search_val");
    public readonly NuiBind<int> SearchObjectType = new NuiBind<int>("search_type_val");
    public readonly NuiBind<string> SearchDistance = new NuiBind<string>("search_dist_val");

    public readonly NuiBind<string> CurrentArea = new NuiBind<string>("area");

    public readonly NuiBind<Color> RowColors = new NuiBind<Color>("obj_row_colors");
    public readonly NuiBind<string> ObjectTypes = new NuiBind<string>("obj_types_val");
    public readonly NuiBind<string> ObjectNames = new NuiBind<string>("obj_names_val");
    public readonly NuiBind<string> ObjectResRefs = new NuiBind<string>("obj_resrefs_val");
    public readonly NuiBind<string> ObjectTags = new NuiBind<string>("obj_tags_val");
    public readonly NuiBind<string> ObjectHPs = new NuiBind<string>("obj_hps_val");
    public readonly NuiBind<string> ObjectCRs = new NuiBind<string>("obj_crs_val");
    public readonly NuiBind<int> ObjectCount = new NuiBind<int>("obj_count");

    // Object List Elements
    public readonly NuiLabel ObjectTypeTexts;
    public readonly NuiLabel ObjectNameTexts;
    public readonly NuiLabel ObjectHPTexts;
    public readonly NuiLabel ObjectCRTexts;
    public readonly NuiLabel ObjectResRefTexts;
    public readonly NuiLabel ObjectTagTexts;

    // Buttons
    public readonly NuiButtonImage ObjectPickerButton;
    public readonly NuiButtonImage SearchButton;
    public readonly NuiButton ChangeAreaButton;
    public readonly NuiCombo ObjectTypeFilter;

    // Visibility
    public readonly NuiBind<bool> UnrestrictedArea = new NuiBind<bool>("vis_area");
    public readonly NuiBind<bool> UnrestrictedType = new NuiBind<bool>("vis_type");

    // Rendered Sub View
    public IReadOnlyList<NuiElement> SubView { get; }

    public ObjectSelectionListView()
    {
      ObjectPickerButton = new NuiButtonImage("dm_findnext")
      {
        Id = "btn_pickobj",
        Aspect = 1f,
      };

      SearchButton = new NuiButtonImage("isk_search")
      {
        Id = "btn_search",
        Aspect = 1f,
      };

      ChangeAreaButton = new NuiButton(CurrentArea)
      {
        Id = "cng_area_btn",
        Tooltip = CurrentArea,
        Visible = UnrestrictedArea,
        Enabled = UnrestrictedArea,
      };

      ObjectTypeFilter = NuiUtils.CreateComboForEnum<ObjectSelectionTypes>(SearchObjectType);
      ObjectTypeFilter.Visible = UnrestrictedType;
      ObjectTypeFilter.Enabled = UnrestrictedType;

      ObjectTypeTexts = new NuiLabel(ObjectTypes)
      {
        Id = ObjectRowId,
        Tooltip = ObjectNames,
        ForegroundColor = RowColors,
      };

      ObjectNameTexts = new NuiLabel(ObjectNames)
      {
        Id = ObjectRowId,
        Tooltip = ObjectNames,
        ForegroundColor = RowColors,
      };

      ObjectHPTexts = new NuiLabel(ObjectHPs)
      {
        Id = ObjectRowId,
        Tooltip = ObjectNames,
        ForegroundColor = RowColors,
      };

      ObjectCRTexts = new NuiLabel(ObjectCRs)
      {
        Id = ObjectRowId,
        Tooltip = ObjectNames,
        ForegroundColor = RowColors,
      };

      ObjectResRefTexts = new NuiLabel(ObjectResRefs)
      {
        Id = ObjectRowId,
        Tooltip = ObjectNames,
        ForegroundColor = RowColors,
      };

      ObjectTagTexts = new NuiLabel(ObjectTags)
      {
        Id = ObjectRowId,
        Tooltip = ObjectNames,
        ForegroundColor = RowColors,
      };

      List<NuiListTemplateCell> rowTemplate = new List<NuiListTemplateCell>
      {
        new NuiListTemplateCell(ObjectTypeTexts)
        {
          Width = 80f,
        },
        new NuiListTemplateCell(ObjectResRefTexts)
        {
          Width = 120f,
        },
        new NuiListTemplateCell(ObjectHPTexts)
        {
          Width = 80f,
        },
        new NuiListTemplateCell(ObjectCRTexts)
        {
          Width = 40f,
        },
        new NuiListTemplateCell(ObjectNameTexts),
        new NuiListTemplateCell(ObjectTagTexts),
      };

      SubView = new List<NuiElement>
      {
        new NuiRow
        {
          Height = 20f,
          Children = new List<NuiElement>
          {
            new NuiSpacer(),
            new NuiLabel("Current Area   ")
            {
              VerticalAlign = NuiVAlign.Bottom,
              HorizontalAlign = NuiHAlign.Right,
              Width = 180f,
            },
          },
        },
        new NuiRow
        {
          Height = 40f,
          Children = new List<NuiElement>
          {
            ObjectPickerButton,
            SearchButton,
            new NuiTextEdit("Search for objects...", Search, 255, false),
            new NuiTextEdit("Dist. (m)", SearchDistance, 10, false)
            {
              Width = 70f,
            },
            ObjectTypeFilter,
            ChangeAreaButton,
          },
        },
        new NuiRow
        {
          Children = new List<NuiElement>
          {
            new NuiLabel("Type")
            {
              Width = 80f,
            },
            new NuiLabel("Res Ref")
            {
              Width = 120f,
            },
            new NuiLabel("HP")
            {
              Width = 80f,
            },
            new NuiLabel("CR")
            {
              Width = 40f,
            },
            new NuiLabel("Name"),
            new NuiLabel("Tag"),
          },
          Height = 20f,
        },
        new NuiList(rowTemplate, ObjectCount)
        {
          RowHeight = 35f,
          Height = 400f,
        },
      };
    }
  }
}
