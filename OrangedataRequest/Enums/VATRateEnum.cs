namespace OrangedataRequest.Enums
{
    /// <summary>
    ///     Ставка НДС
    /// </summary>
    public enum VATRateEnum
    {
        /// <summary>
        ///     ставка НДС 18%
        /// </summary>
        VAT20 = 1,
        /// <summary>
        ///     ставка НДС 10%
        /// </summary>
        VAT10,
        /// <summary>
        ///     ставка НДС расч. 20/120
        /// </summary>
        VAT120,
        /// <summary>
        ///     ставка НДС расч. 10/110
        /// </summary>
        VAT110,
        /// <summary>
        ///     ставка НДС 0%
        /// </summary>
        VAT0,
        /// <summary>
        ///     НДС не облагается
        /// </summary>
        NONE
    }
}
