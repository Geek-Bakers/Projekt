using System;

/// <summary>
/// Automatic error Class from template
/// </summary>

namespace Projekt.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
