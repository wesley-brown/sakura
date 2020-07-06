using System.Collections.Generic;
using UnityEngine;

namespace Sakura.Interactions
{
    public sealed class ConditionListParameter : MonoBehaviour
    {
        public List<Condition> Literal = null;
        public ConditionListParameter Reference = null;

        public List<Condition> Value
        {
            get
            {
                if (Reference)
                {
                    return Reference.Value;
                }
                else
                {
                    return new List<Condition>(Literal);
                }
            }
        }
    }
}
