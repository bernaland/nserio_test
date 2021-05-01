<template>
    <table>
        <th>
            <td colspan="2">
                Add New
            </td>
        </th>
        <tr>
            <td class="label">
                Title
            </td>
            <td>
                <input type="text" v-model="title"/>
            </td>
        </tr>
        <tr>
            <td class="label">Year</td>
            <td>
                <input type="number" v-model="year"/>
            </td>
        </tr>
        <tr>
            <td class="label">Genre</td>
            <td>
                <input type="text" v-model="genre"/>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <button @click="onSaveAlbum">Add</button>
            </td>
        </tr>
    </table>
</template>
<script>
export default {
    name:'AlbumCreator',
    data() {
        return {
            title:'',
            year:2021,
            genre:''
        }
    },
    methods: {
        onSaveAlbum(){
            let self = this;
            if (self.title != null && self.title.length < 1) {
                alert("Debe indicar el titulo del album");
                return;
            }
            if (self.year == null) {
                alert("Debe indicar el año del album");
                return;
            }
            if (self.genre != null && self.genre.length < 1) {
                alert("Debe indicar el genero del album");
                return;
            }
            self.$emit("saveAlbum",{
                title:self.title,
                year:self.year,
                genre:self.genre
            });
            self.title='';
            self.year=2021;
            self.genre='';
        }
    },
}
</script>
<style scoped>
.label {
    font-weight: bold;
}
</style>