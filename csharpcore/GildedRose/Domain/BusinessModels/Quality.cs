using System;

namespace GildedRose.Domain.BusinessModels
{
    public class Quality : IEquatable<Quality>, IComparable<Quality>
    {
        private int value;

        public Quality(int value)
        {
            this.value = value;
        }

        public void IncreaseBy(int increment)
        {
            value += increment;
            if (value > 50)
            {
                value = 50;
            }
        }

        public void DecreaseBy(int increment)
        {
            value -= increment;
            if (value < 0)
            {
                value = 0;
            }
        }
        
        public void Increase()
        {
            IncreaseBy(1);
        }

        public void Decrease()
        {
            DecreaseBy(1);
        }

        public void DropTo(int newValue)
        {
            value = newValue;
        }

        public override string ToString()
        {
            return value.ToString();
        }

        public int CompareTo(Quality other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return value.CompareTo(other.value);
        }

        public bool Equals(Quality other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return value == other.value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Quality)obj);
        }

        public override int GetHashCode()
        {
            return value;
        }
        
        public static bool operator >(Quality left, Quality right) => left.value > right.value;
        public static bool operator >=(Quality left, Quality right) => left.value >= right.value;
        public static bool operator <(Quality left, Quality right) => left.value < right.value;
        public static bool operator <=(Quality left, Quality right) => left.value <= right.value;
        public static bool operator ==(Quality left, Quality right) => Equals(left, right);
        public static bool operator !=(Quality left, Quality right) => !Equals(left, right);
    }
}