﻿/**
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
/**
 * Analyzer for Russian language. Supports an external list of stopwords (words that
 * will not be indexed at all).
 * A default set of stopwords is used unless an alternative list is specified.
 *
 *
 * @version $Id: RussianAnalyzer.java 564236 2007-08-09 15:21:19Z gsingers $
 */
/**
 * Port from Java by Janus team
 */
using System.Collections;
using System.IO;
using System.Text;

namespace Lucene.Net.Analysis.Ru
{
	public sealed class RussianAnalyzer : Analyzer
	{
		// letters (currently unused letters are commented out)
		private const char A =    (char)0;
		private const char B =    (char)1;
		private const char V =    (char)2;
		private const char G =    (char)3;
		private const char D =    (char)4;
		private const char E =    (char)5;
		private const char ZH =   (char)6;
		private const char Z =    (char)7;
		private const char I =    (char)8;
		private const char I_ =   (char)9;
		private const char K =    (char)10;
		private const char L =    (char)11;
		private const char M =    (char)12;
		private const char N =    (char)13;
		private const char O =    (char)14;
		private const char P =    (char)15;
		private const char R =    (char)16;
		private const char S =    (char)17;
		private const char T =    (char)18;
		private const char U =    (char)19;
		//private const char F = (char)20;
		private const char X =    (char)21;
		//private const char TS = (char)22;
		private const char CH =   (char)23;
		private const char SH =   (char)24;
		private const char SHCH = (char)25;
		//private final static char HARD = 26;
		private const char Y =    (char)27;
		private const char SOFT = (char)28;
		private const char AE =   (char)29;
		private const char IU =   (char)30;
		private const char IA =   (char)31;

	/**
	 * List of typical Russian stopwords.
	 */
	private static readonly char[][] RUSSIAN_STOP_WORDS = {
		new[]{A},
		new[]{B, E, Z},
		new[]{B, O, L, E, E},
		new[]{B, Y},
		new[]{B, Y, L},
		new[]{B, Y, L, A},
		new[]{B, Y, L, I},
		new[]{B, Y, L, O},
		new[]{B, Y, T, SOFT},
		new[]{V},
		new[]{V, A, M},
		new[]{V, A, S},
		new[]{V, E, S, SOFT},
		new[]{V, O},
		new[]{V, O, T},
		new[]{V, S, E},
		new[]{V, S, E, G, O},
		new[]{V, S, E, X},
		new[]{V, Y},
		new[]{G, D, E},
		new[]{D, A},
		new[]{D, A, ZH, E},
		new[]{D, L, IA},
		new[]{D, O},
		new[]{E, G, O},
		new[]{E, E},
		new[]{E, I_,},
		new[]{E, IU},
		new[]{E, S, L, I},
		new[]{E, S, T, SOFT},
		new[]{E, SHCH, E},
		new[]{ZH, E},
		new[]{Z, A},
		new[]{Z, D, E, S, SOFT},
		new[]{I},
		new[]{I, Z},
		new[]{I, L, I},
		new[]{I, M},
		new[]{I, X},
		new[]{K},
		new[]{K, A, K},
		new[]{K, O},
		new[]{K, O, G, D, A},
		new[]{K, T, O},
		new[]{L, I},
		new[]{L, I, B, O},
		new[]{M, N, E},
		new[]{M, O, ZH, E, T},
		new[]{M, Y},
		new[]{N, A},
		new[]{N, A, D, O},
		new[]{N, A, SH},
		new[]{N, E},
		new[]{N, E, G, O},
		new[]{N, E, E},
		new[]{N, E, T},
		new[]{N, I},
		new[]{N, I, X},
		new[]{N, O},
		new[]{N, U},
		new[]{O},
		new[]{O, B},
		new[]{O, D, N, A, K, O},
		new[]{O, N},
		new[]{O, N, A},
		new[]{O, N, I},
		new[]{O, N, O},
		new[]{O, T},
		new[]{O, CH, E, N, SOFT},
		new[]{P, O},
		new[]{P, O, D},
		new[]{P, R, I},
		new[]{S},
		new[]{S, O},
		new[]{T, A, K},
		new[]{T, A, K, ZH, E},
		new[]{T, A, K, O, I_},
		new[]{T, A, M},
		new[]{T, E},
		new[]{T, E, M},
		new[]{T, O},
		new[]{T, O, G, O},
		new[]{T, O, ZH, E},
		new[]{T, O, I_},
		new[]{T, O, L, SOFT, K, O},
		new[]{T, O, M},
		new[]{T, Y},
		new[]{U},
		new[]{U, ZH, E},
		new[]{X, O, T, IA},
		new[]{CH, E, G, O},
		new[]{CH, E, I_},
		new[]{CH, E, M},
		new[]{CH, T, O},
		new[]{CH, T, O, B, Y},
		new[]{CH, SOFT, E},
		new[]{CH, SOFT, IA},
		new[]{AE, T, A},
		new[]{AE, T, I},
		new[]{AE, T, O},
		new[]{IA}
	};

	/**
	 * Contains the stopwords used with the StopFilter.
	*/
	private readonly Hashtable _stopSet = new Hashtable();

	/**
	 * Charset for Russian letters.
	 * Represents encoding for 32 lowercase Russian letters.
	 * Predefined charsets can be taken from RussianCharSets class
	*/
	private readonly char[] _charset;


	public RussianAnalyzer()
	{
		_charset = RussianCharsets.UnicodeRussian;
		_stopSet = StopFilter.MakeStopSet(MakeStopWords(RussianCharsets.UnicodeRussian));
	}

	/**
	 * Builds an analyzer.
	*/
	public RussianAnalyzer(char[] charset)
	{
		_charset = charset;
		_stopSet = StopFilter.MakeStopSet(MakeStopWords(charset));
	}

	/**
	 * Builds an analyzer with the given stop words.
	*/
	public RussianAnalyzer(char[] charset, string[] stopwords)
	{
		_charset = charset;
		_stopSet = StopFilter.MakeStopSet(stopwords);
	}

	// Takes russian stop words and translates them to a String array, using
	// the given charset
	private static string[] MakeStopWords(char[] charset)
	{
		var res = new string[RUSSIAN_STOP_WORDS.Length];
		for (var i = 0; i < res.Length; i++)
		{
			var theStopWord = RUSSIAN_STOP_WORDS[i];
			// translate the word, using the charset
			var theWord = new StringBuilder();
			for (var j = 0; j < theStopWord.Length; j++)
				theWord.Append(charset[theStopWord[j]]);
			res[i] = theWord.ToString();
		}
		return res;
	}

	/**
	 * Builds an analyzer with the given stop words.
	 * @todo create a Set version of this ctor
	*/
	public RussianAnalyzer(char[] charset, IDictionary stopwords)
	{
		_charset = charset;
		_stopSet = new Hashtable(stopwords);
	}

	/**
	 * Creates a TokenStream which tokenizes all the text in the provided Reader.
	 *
	 * @return  A TokenStream build from a RussianLetterTokenizer filtered with
	 *                  RussianLowerCaseFilter, StopFilter, and RussianStemFilter
	*/
	public override TokenStream TokenStream(string fieldName, TextReader reader)
	{
		TokenStream result = new RussianLetterTokenizer(reader, _charset);
		result = new RussianLowerCaseFilter(result, _charset);
		result = new StopFilter(result, _stopSet);
		result = new RussianStemFilter(result, _charset);
		return result;
	}
}
}