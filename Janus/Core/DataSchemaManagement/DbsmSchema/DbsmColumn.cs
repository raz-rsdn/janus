﻿using System.ComponentModel;
using System.Xml.Serialization;

namespace Rsdn.Janus
{

	public class DbsmColumn : DbsmNamedElement
	{
		private const DbsmColumnType _defaultType = DbsmColumnType.Unknown;
		private DbsmColumnType _type = _defaultType;

		[XmlAttribute("type")]
		[DefaultValue(_defaultType)]
		public DbsmColumnType Type
		{
			get { return _type; }
			set { _type = value; }
		}

		private const bool _defaultAutoIncrement = false;

		[XmlAttribute("auto-increment")]
		[DefaultValue(_defaultAutoIncrement)]
		public bool AutoIncrement { get; set; }

		private const int _defaultSeed = 0;

		[XmlAttribute("seed")]
		[DefaultValue(_defaultSeed)]
		public int Seed { get; set; }

		private const int _defaultIncrement = 0;

		[XmlAttribute("increment")]
		[DefaultValue(_defaultIncrement)]
		public int Increment { get; set; }

		[XmlAttribute("nullable")]
		public bool Nullable { get; set; }

		[XmlAttribute("size")]
		public long Size { get; set; }

		private const int _defaultDecimalScale = 0;

		[XmlAttribute("decimal-scale")]
		[DefaultValue(_defaultDecimalScale)]
		public int DecimalScale { get; set; }

		private const int _defaultDecimalPrecision = 0;

		[XmlAttribute("decimal-precision")]
		[DefaultValue(_defaultDecimalPrecision)]
		public int DecimalPrecision { get; set; }

		[XmlAttribute("default-value")]
		public string DefaultValue { get; set; }

		#region Methods

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			if (!(obj is DbsmColumn))
				return false;

			var column = (DbsmColumn)obj;
			if (!
				(column.Name == Name &&
				//column.ComputedBy == ComputedBy &&
				//column.DecimalPrecision == DecimalPrecision &&
				//column.DecimalScale == DecimalScale && 
				column.DefaultValue == DefaultValue &&
				column.AutoIncrement == AutoIncrement && column.Increment == Increment && column.Seed == Seed &&
				column.Nullable == Nullable && column.Type == Type))
				return false;

			switch (Type)
			{
				case DbsmColumnType.Character:
				case DbsmColumnType.CharacterVaring:
				case DbsmColumnType.NCharacter:
				case DbsmColumnType.NCharacterVaring:
				case DbsmColumnType.Binary:
				case DbsmColumnType.BinaryVaring:
					if (column.Size != Size)
						return false;
					break;
				case DbsmColumnType.Float:
				case DbsmColumnType.Real:
				case DbsmColumnType.DoublePrecision:
					if (column.DecimalPrecision != DecimalPrecision)
						return false;
					break;
				case DbsmColumnType.Decimal:
				case DbsmColumnType.Numeric:
					if (column.DecimalPrecision != DecimalPrecision && column.DecimalScale != DecimalScale)
						return false;
					break;
			}

			return true;
		}

		public override int GetHashCode()
		{
			return
				(string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode()) ^
				(string.IsNullOrEmpty(DefaultValue) ? 0 : DefaultValue.GetHashCode()) ^
				(AutoIncrement ? 1 : 0) ^
				Increment ^
				Seed ^
				(Nullable ? 2 : 0) ^
				(int)Type;
		}

		#endregion
	}
	
}