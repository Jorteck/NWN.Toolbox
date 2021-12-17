using System;
using System.Collections.Generic;
using System.Linq;
using Anvil.API;
using Anvil.API.Events;
using Anvil.Services;

namespace Jorteck.Toolbox
{
  public sealed class ToolboxWindowController : WindowController<ToolboxWindowView>
  {
    [Inject]
    public Lazy<IEnumerable<IWindowView>> AvailableWindows { private get; init; }

    [Inject]
    public Lazy<WindowManager> WindowManager { private get; init; }

    [Inject]
    public ConfigService ConfigService { private get; init; }

    private List<IWindowView> allWindows;
    private List<IWindowView> visibleWindows;

    public override void Init()
    {
      WindowConfig filterConfig = ConfigService.Config?.ToolboxWindows;
      IEnumerable<IWindowView> toolboxWindows;

      if (filterConfig?.ListMode == ListMode.Whitelist)
      {
        toolboxWindows = AvailableWindows.Value.Where(view => view.ListInToolbox && filterConfig.Windows?.Contains(view.Id) == true);
      }
      else if (filterConfig?.ListMode == ListMode.Blacklist && filterConfig.Windows != null && filterConfig.Windows.Count > 0)
      {
        toolboxWindows = AvailableWindows.Value.Where(view => view.ListInToolbox && filterConfig.Windows?.Contains(view.Id) == false);
      }
      else
      {
        toolboxWindows = AvailableWindows.Value;
      }

      allWindows = toolboxWindows.OrderBy(view => view.Title).ToList();
      RefreshWindowList();
    }

    public override void ProcessEvent(ModuleEvents.OnNuiEvent eventData)
    {
      switch (eventData.EventType)
      {
        case NuiEventType.Click:
          HandleButtonClick(eventData);
          break;
      }
    }

    protected override void OnClose()
    {
      visibleWindows = null;
    }

    private void HandleButtonClick(ModuleEvents.OnNuiEvent eventData)
    {
      if (eventData.ElementId == View.SearchButton.Id)
      {
        RefreshWindowList();
      }
      else if (eventData.ElementId == View.OpenWindowButton.Id && visibleWindows != null && eventData.ArrayIndex >= 0 && eventData.ArrayIndex < visibleWindows.Count)
      {
        IWindowView windowView = visibleWindows[eventData.ArrayIndex];
        WindowManager.Value.OpenWindow(Player, windowView);
      }
    }

    private void RefreshWindowList()
    {
      string search = GetBindValue(View.Search);
      visibleWindows = allWindows.Where(view => view.Title.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

      List<string> windowNames = visibleWindows.Select(view => view.Title).ToList();
      SetBindValues(View.WindowNames, windowNames);
      SetBindValue(View.WindowCount, visibleWindows.Count);
    }
  }
}
