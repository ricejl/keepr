<template>
  <div class="dashboard">
    <h1>WELCOME TO THE DASHBOARD</h1>
    public {{ publicKeeps }} user {{ userKeeps }}
    <div>
      <form>
        <input type="text" placeholder="Title" v-model="newKeep.name" />
        <input
          type="text"
          placeholder="Description"
          v-model="newKeep.description"
        />
        <input type="text" placeholder="Image Url" v-model="newKeep.imgUrl" />
        <!-- FIXME add checkbox for private -->
      </form>
    </div>
  </div>
</template>

<script>
export default {
  mounted() {},
  data() {
    return {
      newKeep: {
        name: "",
        description: "",
        imgUrl: "",
        isPrivate: false
      }
    };
  },
  computed: {},
  methods: {
    createKeep() {
      this.$store.dispatch("createKeep", newKeep);
      this.newKeep = {
        name: "",
        description: "",
        imgUrl: "",
        isPrivate: false
      };
    }
  }
};
</script>

<style></style>
