import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public words = 3;
  public vowels = 2;
  public lines = 2;

  public inputText = [
    "I pledge allegiance to the Flag of the United States of America,",
    "and to the Republic for which it stands, one Nation under God,",
    "indivisible, with liberty and justice for all, should be rendered",
    "by standing at attention facing the flag with the right hand over",
    "the heart. When not in uniform men should remove any non-religious",
    "headdress with their right hand and hold it at the left shoulder,",
    "the hand being over the heart. Persons in uniform should remain",
    "silent, face the flag, and render the military salute."
  ];

  public resultLines;
  public resultWords;

  ngOnInit() {
    this.countVowels();
  }

  public countVowels() {
    let matchedLines = 0;
    let matchedWords = 0;
    for (let i = 0; i < this.inputText.length; i++) {
      let matchesLine = (i + 1) % this.lines === 0;
      if (matchesLine) {
        matchedLines++;
        let line = this.inputText[i];
        let words = line.split(" ");
        for (let j = 0; j < words.length; j++) {
          let matchesWord = (j + 1) % this.words === 0;
          if (matchesWord) {
            let word = words[j];
            if (this.hasVowels(this.vowels, word)) {
              matchedWords++;
            }
          }
        }
      }
    }
    this.resultLines = matchedLines;
    this.resultWords = matchedWords;
  }

  private hasVowels(numberOfVowels: number, word: string): boolean {
    const matchedVowels = word.match(/[aeiou]/gi);
    let length = matchedVowels === null ? 0 : matchedVowels.length;
    return length >= numberOfVowels;
  }
}
