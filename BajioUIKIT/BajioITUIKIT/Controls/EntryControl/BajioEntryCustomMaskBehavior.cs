using System.Text;
using System.Text.RegularExpressions;
using BajioITUIKIT.Enums;

namespace BajioITUIKIT.Controls
{
    public class BajioEntryCustomMaskBehavior
    {
        #region Public Methods
        /// <summary>
        /// Processes the mask.
        /// </summary>
        /// <returns>The mask.</returns>
        /// <param name="entryText">Entry text.</param>
        /// <param name="oldString">Old string.</param>
        /// <param name="newString">New string.</param>
        /// <param name="mask">Mask.</param>
        public string ProcessMask(string entryText, string oldString, string newString, string mask, EntryMaskType? maskType = null)
        {
            if (maskType.HasValue && (maskType.Value == EntryMaskType.PhoneSecond))
            {
                string digitsText = Regex.Replace(mask, @"[^#]", "");
                string text = Regex.Replace(entryText, @"[^\d]", "");

                int length = text.Length < digitsText.Length ? text.Length : digitsText.Length;
                text = text.Substring(0, length);

                string formattedText = string.Empty;

                StringBuilder masksection = new StringBuilder();
                for (int i = 0, j = 0; i < text.Length; j++)
                {
                    if (j < mask.Length)
                    {
                        masksection.Append(mask[j]);

                        if (mask[j] == '#')
                        {
                            i++;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (long.TryParse(text, out long value))
                {
                    formattedText = value.ToString(masksection.ToString());
                }

                return formattedText;
            }
            else
            {
                string output = entryText;
                if (oldString != null)
                {
                    if (ReturnCheck(oldString, mask))
                    {
                        if (newString.Length > oldString.Length)
                        {
                            if (mask.Length >= newString.Length)
                            {
                                var ln = entryText.Length - 1;
                                var st = mask.Substring(ln, 1);
                                string newstr = string.Empty;
                                if (oldString.Length > 0)
                                {
                                    newstr = newString.Substring(newString.Length - 1);
                                }
                                else
                                {
                                    newstr = newString;
                                }
                                if (output.Length > 1)
                                {
                                    output = output.Remove(output.Length - 1, 1);
                                }
                                else
                                {
                                    output = string.Empty;
                                }
                                if (st == "#")
                                {
                                    output = output + newstr;
                                }
                                else
                                {
                                    foreach (var s in mask.Substring(ln))
                                    {
                                        if (s == '#')
                                        {
                                            output = output + newstr;
                                            break;
                                        }
                                        output = output + s;
                                    }
                                }
                            }
                            else
                            {
                                output = oldString;
                            }
                        }
                    }
                }

                return output;
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Returns the check.
        /// </summary>
        /// <returns><c>true</c>, if check was returned, <c>false</c> otherwise.</returns>
        /// <param name="oldValue">Old value.</param>
        /// <param name="mask">Mask.</param>
        private bool ReturnCheck(string oldValue, string mask)
        {
            int i = 0;
            if (mask.Length < oldValue.Length)
            {
                return false;
            }

            foreach (var s in mask.Substring(0, oldValue.Length))
            {
                if (s.ToString() != "#" && s.ToString() != oldValue.Substring(i, 1))
                {
                    return false;
                }
                i++;
            }
            return true;
        }
        #endregion


     
    }
}
