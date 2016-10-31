﻿using System;
using System.Collections.Generic;

namespace SaintCoinach.Ex {
    public abstract class DataRowBase : IDataRow {
        #region Fields

        private WeakReference<object>[] _ValueReferences;

        #endregion

        #region Constructors

        protected DataRowBase(IDataSheet sheet, int key, int offset) {
            Sheet = sheet;
            Key = key;
            Offset = offset;
            _ValueReferences = new WeakReference<object>[Sheet.Header.ColumnCount];
        }

        #endregion

        public IDataSheet Sheet { get; private set; }
        ISheet IRow.Sheet { get { return Sheet; } }
        public int Key { get; private set; }
        public int Offset { get; private set; }

        #region IRow Members

        public virtual object this[int columnIndex] {
            get {
                object value;

                if (_ValueReferences[columnIndex] != null && _ValueReferences[columnIndex].TryGetTarget(out value))
                    return value;

                var column = Sheet.Header.GetColumn(columnIndex);
                value = column.Read(Sheet.GetBuffer(), this);

                if (_ValueReferences[columnIndex] != null)
                    _ValueReferences[columnIndex].SetTarget(value);
                else
                    _ValueReferences[columnIndex] = new WeakReference<object>(value);

                return value;
            }
        }

        public virtual object GetRaw(int columnIndex)
        {
            var column = Sheet.Header.GetColumn(columnIndex);
            return column.ReadRaw(Sheet.GetBuffer(), this);
        }

        #endregion
    }
}