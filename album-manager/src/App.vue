<template>
  <div id="app">
    <table>
      <tr>
        <td>
          <album-creator @saveAlbum="onSaveAlbum"/>
        </td>
      </tr>
      <tr>
        <td>
          <album-list :new-album="currentAlbum"/>
        </td>
      </tr>
    </table>
  </div>
</template>

<script>
export default {
  name: 'App',
  components: {
    AlbumCreator:()=>import('./components/AlbumCreator.vue'),
    AlbumList: () => import('./components/AlbumList.vue')
  },
  data() {
    return {
      currentAlbum:{}
    }
  },
  methods: {
    onSaveAlbum(albumData){
      let self = this;
      self.currentAlbum={...albumData};
      setTimeout(() => {
        self.currentAlbum=null;
      }, 100);
    }
  },
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
</style>
