<template>
  <div id="app">
    <table>
        <tr>
            <td>Juega</td>
            <td>{{teamName}}</td>
            <td>
                <img class="player" :src="figureImage"/>
            </td>
        </tr>
      <tr v-for="(row, idx) in gameField" :key="`Row_${idx}`">
          <cell v-for="(col, jdx) in row" :key="`Col_${idx}_${jdx}`" 
            :figure="gameField[idx][jdx]"
            @cellClick="lockCell(idx, jdx)"></cell>
      </tr>
      <tr >
          <td colspan="3">
              <button @click="initField">Reset</button>
          </td>
      </tr>
    </table>
  </div>
</template>

<script>
// import HelloWorld from './components/HelloWorld.vue'

export default {
  name: 'App',
  components: {
    // HelloWorld,
    Cell: () => import('./components/Cell.vue')
  },
  data() {
    return {
      gameField: [],
      player: 0,
      playersFigures:[]
    }
  },
  beforeMount() {
    this.initField();
  },
  methods: {
      initField() {
          this.gameField=[];
          this.player=0;
          this.gameField.push([
              '','',''
          ]);
          this.gameField.push([
              '','',''
          ]);
          this.gameField.push([
              '','',''
          ]);
          this.playersFigures = Math.random() < 0.5 ?
            ['x', 'o'] : ['o', 'x'];
      },
      lockCell(row, col) {
          this.gameField[row][col]=this.currentFigure;
          this.checkWinner()
          this.player=this.player===0?1:0;
      },
      checkWinner() {
          if (this.checkDiagonals() || this.checkHorizontal() || this.checkVertical()){
              let winnerTeam = this.teamName;
              setTimeout(() => {
                  alert(`Ha ganado ${winnerTeam}`);
                this.initField();
              }, 150);
          }
      },
      checkDiagonals(){
          let isCompleteDiagonal = true;
          for (let idx = 0; idx < this.gameField.length; idx++) {
              const item = this.gameField[idx][idx];
              isCompleteDiagonal &&=(item === this.currentFigure);
              if (!isCompleteDiagonal) {
                  break;
              }
          }
          if (!isCompleteDiagonal) {
              isCompleteDiagonal=true;
              for (let jdx = 0; jdx < this.gameField.length; jdx++) {
                  const inv_item = this.gameField[2-jdx][jdx];
                  isCompleteDiagonal &&=(inv_item === this.currentFigure);
                  if (!isCompleteDiagonal) {
                    break;
                }
              }
          }
          return isCompleteDiagonal;
      },
      checkHorizontal(){
          let isCompleteRow=true;
          for (let row = 0; row < this.gameField.length; row++) {
              const column = this.gameField[row];
              for (let col = 0; col < column.length; col++) {
                  const item = column[col];
                  isCompleteRow &&= (item === this.currentFigure);
                  if (!isCompleteRow) {
                      break;
                  }
              }
              if (isCompleteRow) {
                  break;
              }
          }
          return isCompleteRow;
      },
      checkVertical() {
          let isCompleteColumn = true;
          for (let col = 0; col < this.gameField.length; col++) {
              for (let row = 0; row < this.gameField.length; row++) {
                  const item = this.gameField[row][col];
                  isCompleteColumn &&= (item === this.currentFigure);
                  if (!isCompleteColumn) {
                      break;
                  }
              }
              if (isCompleteColumn) {
                  break;
              }
          }
          return isCompleteColumn;
      }
  },
  computed:{
      teamName(){
          return `Team ${this.player +1}`;
      },
      currentFigure() {
          return this.playersFigures[this.player];
      },
      figureImage() {
        return require(`@/assets/${this.currentFigure}.png`);
      }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

img.player {
    max-width: 40px;
    max-height: 40px;
}
</style>
