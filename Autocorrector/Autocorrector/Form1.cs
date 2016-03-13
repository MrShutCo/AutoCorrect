using DynamicSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autocorrector {
    public partial class Form1 : Form {

        public Dictionary<string, int> WordCountList;
        public List<string> WordList;
        SpellCorrector SP;
        public int TotalWords;

        public Form1() {
            InitializeComponent();
            WordCountList = Helpers.LoadCorpus();
            SP = new SpellCorrector(WordCountList);
            WordList = new List<string>();
            foreach (KeyValuePair<string, int> kvp in WordCountList) {
                WordList.Add(kvp.Key);
                TotalWords += kvp.Value;
            }
        }

        private void ErrorCheckButton_Click(object sender, EventArgs e) {
            
        }

        private void TextArea_TextChanged(object sender, EventArgs e) {
            string paragraph = TextArea.Text;
            List<string> wordsSaid = Helpers.ConvertStringToList(paragraph);
            foreach (string s in wordsSaid) {
                if (!Helpers.IsValidWord(WordList, s)) {
                    if (TextArea.Find(s) != -1) {
                        TextArea.SelectionStart = TextArea.Find(s);
                        TextArea.SelectionLength = TextArea.SelectionStart + s.Length;
                        TextArea.SelectionColor = Color.Red;
                    }
                }
                else {
                    TextArea.SelectionStart = TextArea.Find(s);
                    TextArea.SelectionLength = TextArea.SelectionStart + s.Length;
                    TextArea.SelectionColor = Color.Black;
                }
            }
        }

        public class SpellCorrector {
            Dictionary<string, int> DWORDS;
            const string ALPHABET = "abcdefghijklmnopqrstuvwxyz";

            public SpellCorrector(Dictionary<string, int> wordList) {
                DWORDS = wordList;
            }

            class StringPair {
                public string a, b;
            }

            List<string> Edits1(string word) {
                var splits = DS.Range(word.Length + 1).Map(i => new StringPair { a = word.Slice(0, i), b = word.Slice(i) });
                var deletes = splits.Map(s => s.a + s.b.Slice(1));
                var transposes = splits.Map(s => s.b.Length > 1 ? s.a + s.b[1] + s.b[0] + s.b.Slice(2) : "**");

                var replaces = new List<string>();
                foreach (var s in splits)
                    foreach (var c in ALPHABET)
                        if (s.b.Length > 0)
                            replaces.Add(s.a + c + s.b.Slice(1, -1));

                var inserts = new List<string>();
                foreach (var s in splits)
                    foreach (var c in ALPHABET)
                        inserts.Add(s.a + c + s.b);

                return deletes.Add(transposes).Add(replaces).Add(inserts);
            }

            List<string> KnownEdits2(string word) {

                var l = new List<string>();
                foreach (var e1 in this.Edits1(word))
                    foreach (var e2 in Edits1(e1))
                        if (this.DWORDS.ContainsKey(e2))
                            l.Add(e2);
                return l;
            }
            List<string> Known(List<string> words) {

                return words.Filter(w => this.DWORDS.ContainsKey(w));
            }
            public string Correct(string word) {

                var candidateWords = this.Known(DS.List(word));
                if (candidateWords.Count == 0)
                    candidateWords = this.Known(this.Edits1(word));
                if (candidateWords.Count == 0)
                    candidateWords = this.KnownEdits2(word);
                if (candidateWords.Count == 0)
                    candidateWords = DS.List(word);

                return this.DWORDS.Max(candidateWords);
            }

        }

        public static class Helpers {

            public static Dictionary<string, int> LoadCorpus() {
                string line;
                Dictionary<string, int> WordCountList = new Dictionary<string, int>();
                System.IO.StreamReader file = new System.IO.StreamReader("Vocabulary.txt");
                while ((line = file.ReadLine()) != null) {
                    string[] entry = line.Split(' ');
                    string key = entry[0];
                    int value = Convert.ToInt32(entry[1]);
                    WordCountList.Add(key, value);
                }
                return WordCountList;
            }

            public static Dictionary<string, int> UpdateCorpus(Dictionary<string, int> WordCountList, string fileName) {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(fileName);
                while ((line = file.ReadLine()) != null) {
                    line = line.ToLower();
                    string[] words = line.Split(' ');
                    foreach (string s in words) {
                        string ss = new string(s.ToCharArray().Where(c => char.IsLetterOrDigit(c) || (c == '\'')).ToArray());

                        if (ss != " ") {
                            if (!WordCountList.ContainsKey(ss)) {
                                WordCountList.Add(ss, 1);
                            }
                            else {
                                WordCountList[ss] += 1;
                            }
                        }
                    }
                }
                file.Close();
                return WordCountList;
            }

            public static void SaveCorpus(Dictionary<string, int> wordlist) {
                System.IO.StreamWriter file = new System.IO.StreamWriter("Vocabulary.txt");
                foreach (KeyValuePair<string, int> kvp in wordlist) {
                    file.WriteLine(kvp.Key + " " + kvp.Value);
                }
            }

            public static bool IsValidWord(List<string> validWords, string s) {
                if (validWords.Contains(s)) {
                    return true;
                }
                return false;
            }

            public static List<string> ValidateWords(string paragraph) {
                paragraph = paragraph.ToLower();
                List<string> words = ConvertStringToList(paragraph);
                List<string> valid = new List<string>();
                foreach (string s in words) {
                    if (!valid.Contains(s)) {
                        valid.Add(s);
                    }
                }
                return valid;
            }

            public static List<string> ConvertStringToList(string paragraph) {
                paragraph = paragraph.ToLower();
                List<string> splitSentence = new List<string>();
                string tempWord = "";
                foreach (char c in paragraph) {
                    if (c == ' ') {
                        if (tempWord != "") {
                            splitSentence.Add(tempWord);
                        }
                        tempWord = "";
                        continue;
                    }
                    if (c == '.' || c == '!' || c == '?' || c == ',') {
                        splitSentence.Add(tempWord);
                        tempWord = "";

                    }
                    else {
                        tempWord += c.ToString();
                    }


                }
                return splitSentence;
            }

            public static List<List<string>> GetSentences(List<string> paragraph) {
                //To hold the sentences (lists of lists)
                List<List<string>> sentences = new List<List<string>>();
                //temp storage until it's added to full list
                List<string> tempSentence = new List<string>();
                //Loop through all words
                foreach (string s in paragraph) {
                    //Check if the sentence has ended
                    if (s == "." || s == "!" || s == "?") {
                        //Assume that we are at the end of a sentence

                        sentences.Add(tempSentence);
                        //Clear sentence
                        tempSentence = new List<string>();
                    }
                    else {
                        //It's not the end, let's add this word to this sentence
                        tempSentence.Add(s);
                    }
                }
                return sentences;
            }



        }
    }
}
