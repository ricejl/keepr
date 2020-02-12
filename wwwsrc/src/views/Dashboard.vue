<template>
  <div class="dashboard">
    <h1>WELCOME TO THE DASHBOARD</h1>
    <div v-if="publicKeeps.length > 0">public {{ publicKeeps }}</div>
    <div v-if="userKeeps.length > 0">user {{ userKeeps }}</div>
    <div>
      <h4>Add New Keep</h4>
      <form @submit.prevent="createKeep">
        <input
          type="text"
          id="name"
          placeholder="Title"
          v-model="newKeep.name"
          required
        />
        <input
          type="text"
          id="description"
          placeholder="Description"
          v-model="newKeep.description"
          required
        />
        <input
          type="text"
          id="imgUrl"
          placeholder="Image Url"
          v-model="newKeep.imgUrl"
          required
        />
        <input
          type="checkbox"
          name="isPrivate"
          id="isPrivate"
          value="false"
          v-model="newKeep.isPrivate.checked"
        />
        <label for="isPrivate">public</label>
        <button type="submit">Add</button>
      </form>
    </div>
  </div>
</template>

<script>
export default {
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  data() {
    return {
      newKeep: {
        name: "",
        description: "",
        imgUrl: "",
        isPrivate: true
      }
    };
  },
  computed: {
    publicKeeps() {
      return (
        this.$store.state.publicKeeps || {
          title: "Loading..."
        }
      );
    },
    userKeeps() {
      return this.$store.state.userKeeps;
    }
  },
  methods: {
    createKeep() {
      let keep = this.newKeep;
      this.$store.dispatch("createKeep", keep);
      this.newKeep = {
        name: "",
        description: "",
        imgUrl: "",
        isPrivate: true
      };
    }
  }
};
</script>

<style></style>
