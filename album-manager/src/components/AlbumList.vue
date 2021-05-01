<template>
    <table v-if="albums.length > 0">
        <tr>
            <th @click="onOrderColumn('title')">Title</th>
            <th @click="onOrderColumn('year')">Year</th>
            <th @click="onOrderColumn('genre')">Genre</th>
            <th>Delete</th>
        </tr>
        <tr v-for="(item, idx) in albums" :key="`Album_${idx}`">
            <td>{{item.title}}</td>
            <td>{{item.year}}</td>
            <td>{{item.genre}}</td>
            <td>
                <button @click="onDeleteAlbum(item.id)">X</button>
            </td>
        </tr>
    </table>
</template>
<script>
export default {
    name:'AlbumList',
    data() {
        return {
            albums:[],
            fieldOrdering:{}
        }
    },
    methods: {
        onDeleteAlbum(albumIdx){
            this.albums.splice(albumIdx, 1);
        },
        onOrderColumn(fieldName) {
            let self = this;
            let currentOrdering = self.fieldOrdering[fieldName];
            // eslint-disable-next-line no-debugger
            debugger;
            switch (currentOrdering) {
                case 0:
                    this.fieldOrdering[fieldName] = 1;
                    break;
                case 1:
                    delete this.fieldOrdering[fieldName];
                    break;
                default:
                    this.fieldOrdering[fieldName] = 0;
                    break;
            }
            let orderSide = self.fieldOrdering[fieldName] || 0;
            let orderFn = orderSide == 0 ? self.ascendingOrdering : self.descendingOrdering;
            self.albums = self.albums.sort((first, second) => orderFn(fieldName, first, second)); 
        },
        ascendingOrdering(fieldName, first, second){
            if (first[fieldName] > second[fieldName]) {
                return 1;
            }
            if (first[fieldName] < second[fieldName]) {
                return -1;
            }
            return 0;
        },
        descendingOrdering(fieldName, first, second){
            if (first[fieldName] > second[fieldName]) {
                return -1;
            }
            if (first[fieldName] < second[fieldName]) {
                return 1;
            }
            return 0;
        }
    },
    props: {
        newAlbum:{
            type:Object,
            required: false
        }
    },
    watch:{
        newAlbum:{
            handler:function(newValue){
                if (newValue && Object.keys(newValue).length > 0) {
                    this.albums.push(newValue);
                }
            },
            deep: true
        }
    },
    computed:{
        finalAlbums(){
            // eslint-disable-next-line no-debugger
            debugger;
            let orderedAlbums = this.albums.map((x, idx) => {
                return {id: idx, ...x};
            });
            return orderedAlbums;
        }
    }
}
</script>