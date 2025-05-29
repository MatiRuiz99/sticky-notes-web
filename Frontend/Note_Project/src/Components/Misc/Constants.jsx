// colorUtils.js
export const getColorByNumber = (number) => {
    const clampedNum = Math.max(1, Math.min(16, number));
    
    const colors = [
        // Original colors
        'rgb(82, 113, 255)',   // #5271FF (Blue)
        'rgb(126, 217, 87)',   // #7ED957 (Green)
        'rgb(255, 87, 87)',    // #FF5757 (Red)
        'rgb(255, 189, 89)',   // #FFBD59 (Orange)
        'rgb(155, 81, 255)',   // #9B51FF (Violet)
        'rgb(255, 124, 216)',   // #FF51CB (Pink)
        'rgb(65, 219, 155)',   // #48DB9D (Mint)
        'rgb(255, 221, 89)',   // #FFDD59 (Yellow)
        'rgb(87, 207, 255)',   // #57CFFF (Sky Blue)
        'rgb(255, 112, 51)',   // #FF8A57 (Coral)
        'rgb(69, 56, 240)',   // #99D957 (Lime)
        'rgb(255, 96, 160)',   // #FF579B (Rose)
        'rgb(81, 255, 203)',   // #51FFCB (Aqua)
        'rgb(255, 135, 108)',   // #FF7151 (Tangerine)
        'rgb(98, 33, 163)',   //rgb(87, 16, 158) (Purple)
        'rgb(87, 255, 138)',   // #57FF8A (Spring Green)
        'rgb(255, 81, 81)'     // #FF5151 (Bright Red)
      ];
  
    return colors[clampedNum - 1];
  };
  