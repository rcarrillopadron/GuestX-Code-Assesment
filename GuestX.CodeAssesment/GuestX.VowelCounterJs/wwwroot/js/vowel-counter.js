(function (guestX, $, document, undefined) {
    var inputText,
        inputWords,
        inputVowels,
        inputLines,
        resultLines,
        resultWords,
        btnCountVowels;

    $(function () {
        inputText = document.getElementById('inputText');
        inputWords = document.getElementById('words');
        inputVowels = document.getElementById('vowels');
        inputLines = document.getElementById('lines');
        resultLines = document.getElementById('resultLines');
        resultWords = document.getElementById('resultWords');
        btnCountVowels = document.getElementById('btnCountVowels');
        $(btnCountVowels).on('click', countVowels);
        inputText.value = [
            "I pledge allegiance to the Flag of the United States of America,",
            "and to the Republic for which it stands, one Nation under God,",
            "indivisible, with liberty and justice for all, should be rendered",
            "by standing at attention facing the flag with the right hand over",
            "the heart. When not in uniform men should remove any non-religious",
            "headdress with their right hand and hold it at the left shoulder,",
            "the hand being over the heart. Persons in uniform should remain",
            "silent, face the flag, and render the military salute."
        ].join("\n");
    });

    function countVowels() {
        var matchedLines = 0,
            matchedWords = 0,
            inputTextValue = inputText.value.split("\n"),
            inputWordsValue = parseInt(inputWords.value, 10),
            inputVowelsValue = parseInt(inputVowels.value, 10),
            inputLinesValue = parseInt(inputLines.value, 10),
            i,
            j,
            line,
            words,
            word,
            matchesLine,
            matchesWord;

        for (i = 0; i < inputTextValue.length; i++) {
            matchesLine = (i + 1) % inputLinesValue === 0;
            if (matchesLine) {
                matchedLines++;
                line = inputTextValue[i];
                words = line.split(" ");
                for (j = 0; j < words.length; j++) {
                    matchesWord = (j + 1) % inputWordsValue === 0;
                    if (matchesWord) {
                        word = words[j];
                        if (hasVowels(inputVowelsValue, word)) {
                            matchedWords++;
                        }
                    }
                }
            }
        }
        resultLines.innerHTML = matchedLines;
        resultWords.innerHTML = matchedWords;
    }
    
    function hasVowels(numberOfVowels, word) {
        var matchedVowels = word.match(/[aeiou]/gi),
            length = matchedVowels === null ? 0 : matchedVowels.length;

        return length >= numberOfVowels;
    }

    guestX.countVowels = countVowels;
})(window.guestX = window.guestX || {}, jQuery, document);