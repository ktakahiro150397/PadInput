﻿
// メモ: 生成されたコードは、少なくとも .NET Framework 4.5または .NET Core/Standard 2.0 が必要な可能性があります。
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
public partial class PadInputSettings
{

    private PadInputSettingsButtonOverlaySettings buttonOverlaySettingsField;

    private PadInputSettingsPOVDirectionImage[] pOVDirectionImagesField;

    /// <remarks/>
    public PadInputSettingsButtonOverlaySettings ButtonOverlaySettings
    {
        get
        {
            return this.buttonOverlaySettingsField;
        }
        set
        {
            this.buttonOverlaySettingsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("POVDirectionImage", IsNullable = false)]
    public PadInputSettingsPOVDirectionImage[] POVDirectionImages
    {
        get
        {
            return this.pOVDirectionImagesField;
        }
        set
        {
            this.pOVDirectionImagesField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PadInputSettingsButtonOverlaySettings
{

    private string baseOverlayImageField;

    private PadInputSettingsButtonOverlaySettingsOverlayImage[] buttonOverlayImagesField;

    /// <remarks/>
    public string BaseOverlayImage
    {
        get
        {
            return this.baseOverlayImageField;
        }
        set
        {
            this.baseOverlayImageField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("OverlayImage", IsNullable = false)]
    public PadInputSettingsButtonOverlaySettingsOverlayImage[] ButtonOverlayImages
    {
        get
        {
            return this.buttonOverlayImagesField;
        }
        set
        {
            this.buttonOverlayImagesField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PadInputSettingsButtonOverlaySettingsOverlayImage
{

    private string imageNameField;

    private PadInputSettingsButtonOverlaySettingsOverlayImageOverlayImagePosition overlayImagePositionField;

    private string buttonField;

    /// <remarks/>
    public string ImageName
    {
        get
        {
            return this.imageNameField;
        }
        set
        {
            this.imageNameField = value;
        }
    }

    /// <remarks/>
    public PadInputSettingsButtonOverlaySettingsOverlayImageOverlayImagePosition OverlayImagePosition
    {
        get
        {
            return this.overlayImagePositionField;
        }
        set
        {
            this.overlayImagePositionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string button
    {
        get
        {
            return this.buttonField;
        }
        set
        {
            this.buttonField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PadInputSettingsButtonOverlaySettingsOverlayImageOverlayImagePosition
{

    private int xField;

    private int yField;

    /// <remarks/>
    public int x
    {
        get
        {
            return this.xField;
        }
        set
        {
            this.xField = value;
        }
    }

    /// <remarks/>
    public int y
    {
        get
        {
            return this.yField;
        }
        set
        {
            this.yField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
public partial class PadInputSettingsPOVDirectionImage
{

    private string directionField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string direction
    {
        get
        {
            return this.directionField;
        }
        set
        {
            this.directionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value
    {
        get
        {
            return this.valueField;
        }
        set
        {
            this.valueField = value;
        }
    }
}

