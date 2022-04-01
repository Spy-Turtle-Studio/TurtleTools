using System;
using UnityEngine;

namespace spyturtlestudio.tools.Editor.CustomInspector
{
    [ AttributeUsage( AttributeTargets.Field ) ]
    public class ConditionalHideAttribute : PropertyAttribute
    {
        public readonly string ConditionalSourceField;
        public string ConditionalSourceField2 = "";
        public bool HideInInspector = true;
        public bool Inverse = false;

        // Use this for initialization
        public ConditionalHideAttribute( string conditionalSourceField )
        {
            ConditionalSourceField = conditionalSourceField;
        }
    }
}