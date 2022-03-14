using System;
using spyturtlestudio.tools.Editor.CustomInspector;
using UnityEngine;
using UnityEngine.UI;

namespace UITools
{
    public class FlexibleGridLayout : LayoutGroup
    {
        [Space]
        [SerializeField] 
        private FitType fitType;

        [SerializeField]
        [ConditionalHide("fixedRows")]
        private int rows = 1;
        [SerializeField] 
        [ConditionalHide("fixedColumns")]
        private int columns = 1;
        
        [Space]
        [SerializeField] 
        private Vector2 spacing;
        
        [HideInInspector] public bool fixedRows = false;
        [HideInInspector] public bool fixedColumns = false;
        
        private int _rows;
        private int _columns;
        private Vector2 _cellSize;

        public override void CalculateLayoutInputHorizontal()
        {
            base.CalculateLayoutInputHorizontal();

            fixedColumns = fitType == FitType.FixedColumns;
            fixedRows = fitType == FitType.FixedRows;

            var squareRoot = Math.Sqrt(transform.childCount);
            switch (fitType)
            {
                case FitType.Uniform:
                    _rows = (int) Math.Ceiling(squareRoot);
                    _columns = (int) Math.Ceiling(squareRoot);
                    break;
                case FitType.Width:
                    _columns = (int) Math.Ceiling(squareRoot);
                    _rows = (int) Math.Ceiling(transform.childCount / (float) _columns);
                    break;
                case FitType.Height:
                    _rows = (int) Math.Ceiling(squareRoot);
                    _columns = (int) Math.Ceiling(transform.childCount / (float) _rows);
                    break;
                case FitType.FixedColumns:
                    _columns = columns;
                    _rows = (int) Math.Ceiling(transform.childCount / (float) _columns);
                    break;
                case FitType.FixedRows:
                    _rows = rows;
                    _columns = (int) Math.Ceiling(transform.childCount / (float) _rows);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            var rect = rectTransform.rect;
            var parentWidth = rect.width;
            var parentHeight = rect.height;
            var cellWidth = parentWidth / _columns - spacing.x / _columns * (_columns - 1) - padding.left / (float)_columns - padding.right / (float)_columns;
            var cellHeight = parentHeight / _rows - spacing.y / _rows * (_rows - 1) - padding.bottom / (float)_rows - padding.top / (float)_rows;
            _cellSize.x = cellWidth;
            _cellSize.y = cellHeight;

            var columnCount = 0;
            var rowCount = 0;
            
            for (var i = 0; i < rectChildren.Count; i++)
            {
                columnCount = i % _columns;
                rowCount = i / _columns;
                
                var xPos = _cellSize.x * columnCount + spacing.x * columnCount + padding.left;
                var yPos = _cellSize.y * rowCount + spacing.y * rowCount + padding.top;
                
                SetChildAlongAxis(rectChildren[i], 0, xPos, _cellSize.x);
                SetChildAlongAxis(rectChildren[i], 1, yPos, _cellSize.y);
            }
        }
        
        public override void CalculateLayoutInputVertical() {}

        public override void SetLayoutHorizontal() {}

        public override void SetLayoutVertical() {}
    }

    public enum FitType
    {
        Uniform,
        Width,
        Height,
        FixedRows,
        FixedColumns
    }
}