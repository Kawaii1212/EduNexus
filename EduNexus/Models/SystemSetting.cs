using System;
using System.Collections.Generic;

namespace EduNexus.Models;

public partial class SystemSetting
{
    public long Id { get; set; }

    public string SettingKey { get; set; } = null!;

    public string? SettingType { get; set; }

    public string? SettingValue { get; set; }

    public int DisplayOrder { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    public virtual User? UpdatedByNavigation { get; set; }
}
