using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOTL.Common.Statistics
{
    public static class Statics
    {
        public static double Mean(List<double> lstValue)
        {
            if (lstValue == null || lstValue.Count == 0)
                return -1;

            double total = 0;
            for (int i = 0; i < lstValue.Count; i++)
            {
                total = total + lstValue[i];
            }
            return total / lstValue.Count;
        }

        public static double Max(List<double> lstValue)
        {
            if (lstValue == null || lstValue.Count == 0)
                return -1;

            int maxIndex = 0;
            for (int i = 1; i < lstValue.Count; i++)
            {
                if (lstValue[i] > lstValue[maxIndex])
                {
                    maxIndex = i;
                }
            }
            return lstValue[maxIndex];
        }

        public static int MaxIndex(List<double> lstValue)
        {
            if (lstValue == null || lstValue.Count == 0)
                return -1;

            int maxIndex = 0;
            for (int i = 1; i < lstValue.Count; i++)
            {
                if (lstValue[i] > lstValue[maxIndex])
                {
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        public static double Min(List<double> lstValue)
        {
            if (lstValue == null || lstValue.Count == 0)
                return -1;

            int minIndex = 0;
            for (int i = 1; i < lstValue.Count; i++)
            {
                if (lstValue[i] < lstValue[minIndex])
                {
                    minIndex = i;
                }
            }
            return lstValue[minIndex];
        }

        public static int MinIndex(List<double> lstValue)
        {
            if (lstValue == null || lstValue.Count == 0)
                return -1;

            int minIndex = 0;
            for (int i = 1; i < lstValue.Count; i++)
            {
                if (lstValue[i] < lstValue[minIndex])
                {
                    minIndex = i;
                }
            }
            return minIndex;
        }

        public static double Median(List<double> lstValue)
        {
            if (lstValue == null || lstValue.Count == 0)
                return -1;

            List<double> lstValueClone = new List<double>();
            lstValueClone.AddRange(lstValue);
            lstValueClone.Sort();
            return lstValueClone[(int)(Math.Round(lstValue.Count / 2.0) - 1)];
        }

        public static double Variance(List<double> lstValue)
        {
            return Variance(lstValue, Mean(lstValue));
        }

        public static double Variance(List<double> lstValue, double nMean)
        {
            if (lstValue == null || lstValue.Count == 0)
                return -1;

            double totalDev = 0;

            for (int i = 0; i < lstValue.Count; i++)
            {
                totalDev = totalDev + (nMean - lstValue[i]) * (nMean - lstValue[i]);
            }

            // Sample estimate of variance so divide by n-1.            
            return totalDev / lstValue.Count;
        }

        public static double StandardDeviation(double nVariance)
        {
            return Math.Sqrt(nVariance);
        }

        public static double StandardDeviation(List<double> lstValue)
        {
            return StandardDeviation(Variance(lstValue));
        }

        public static double UpperBound(double nMean, double nDeviation, double nSigma)
        {
            return (nMean + nSigma * nDeviation);
        }

        public static double Lowerbound(double nMean, double nDeviation, double nSigma)
        {
            return (nMean - nSigma * nDeviation);
        }

        public static double Cp(double nMax, double nMin, double nSigma)
        {
            if (nSigma == 0)
                return -1;

            double nValue = (nMax - nMin) / (6 * nSigma);
            return nValue;
        }

        public static double Cpk(double nMax, double nMean, double nSigma)
        {
            if (nSigma == 0)
                return -1;

            double nValue = (nMax - nMean) / (3 * nSigma);
            return nValue;
        }
    }
}
