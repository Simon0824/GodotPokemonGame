using Game.Core;
using Game.UI;
using Godot;
using Godot.Collections;
using System;

namespace Game.Gameplay;

[Tool]
public partial class Sign : StaticBody2D
{
    [Export]
    public Array<string> Messages;

    private SignsType _signStyle = SignsType.METAL;

    [Export]
    public SignsType Signstyle
    {
        get => _signStyle;
        set
        {
            if (_signStyle != value)
            {
                _signStyle = value;
                UpdateSprite();
            }
        }
    }

    private Sprite2D _sprite2D;

    private readonly Dictionary<SignsType, AtlasTexture> _textures = new()
    {
        {SignsType.METAL, GD.Load<AtlasTexture>("res://resources/textures/sign_metal.tres")},
        {SignsType.WOOD, GD.Load<AtlasTexture>("res://resources/textures/sing_wood.tres")},
    };

    public override void _Ready()
    {
        _sprite2D ??= GetNode<Sprite2D>("Sprite2D");
        UpdateSprite();
    }


    public void UpdateSprite()
    {
        if (_sprite2D == null)
        {
            _sprite2D = GetNodeOrNull<Sprite2D>("Sprite2D");

            if (_sprite2D == null)
            {
                Logger.Error("Sprite2D not found");
                return;
            }
        }

        if (_textures.TryGetValue(Signstyle, out var texture))
        {
            _sprite2D.Texture = texture;
        }
        else
        {
            Logger.Error($"No textures found for {Signstyle}");
            _sprite2D.Texture = null;
        }
    }

    public void PlayMessage()
    {
        MessageManager.PlayText([.. Messages]);
    }
}
