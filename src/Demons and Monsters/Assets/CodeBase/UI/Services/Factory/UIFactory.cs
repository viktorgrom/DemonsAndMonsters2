using System.Runtime.Serialization;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Services.PersistentProgress;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;
using CodeBase.UI.Windows;
using UnityEngine;

namespace CodeBase.UI.Services.Factory
{
  public class UIFactory : IUIFactory
  {
    private const string UIRootPath = "UI/UIRoot";
    private readonly IAssetProvider _assets;
    private readonly IStaticDataService _staticData;
    
    private Transform _uiRoot;
    private readonly IPersistentProgressService _progressService;

    public UIFactory(IAssetProvider assets, IStaticDataService staticData, IPersistentProgressService progressService)
    {
      _assets = assets;
      _staticData = staticData;
      _progressService = progressService;
    }

    public void CreateShop()
    {
      WindowConfig confing = _staticData.ForWindow(WindowId.Shop);
      WindowBase window = Object.Instantiate(confing.Template, _uiRoot);
      window.Construct(_progressService);
    }

    public void CreateUIRoot() => 
      _uiRoot = _assets.Instantiate(UIRootPath).transform;
  }
}