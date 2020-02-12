<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col">
        <h1>WELCOME TO THE DASHBOARD</h1>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <div class="card-columns" v-if="publicKeeps.length > 0">
          <keep
            v-for="keep in publicKeeps"
            :key="keep.id"
            :keepData="keep"
          ></keep>
        </div>
      </div>
      <!-- public {{ publicKeeps }} -->
    </div>
    <hr />
    <div class="row">
      <div class="col">
        <h3>Mine. All mine.</h3>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <div class="card-columns" v-if="userKeeps.length > 0">
          <!-- user {{ userKeeps }} -->
          <keep
            v-for="keep in userKeeps"
            :key="keep.id"
            :keepData="keep"
          ></keep>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col">
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
            id="img"
            placeholder="Image Url"
            v-model="newKeep.img"
            required
          />
          <input
            type="checkbox"
            name="isPrivate"
            id="isPrivate"
            v-model="newKeep.isPrivate"
          />
          <label for="isPrivate">private</label>
          <button type="submit">Add</button>
        </form>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h4>Add New Vault</h4>
        <form @submit.prevent="createVault">
          <input
            type="text"
            id="name"
            placeholder="Title"
            v-model="newVault.name"
            required
          />
          <input
            type="text"
            id="description"
            placeholder="Description"
            v-model="newVault.description"
            required
          />
          <button type="submit">Add</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import Keep from "../components/Keep";

export default {
  name: "dashboard",
  mounted() {
    this.$store.dispatch("getKeeps");
  },
  data() {
    return {
      newKeep: {
        name: "",
        description: "",
        img: "",
        isPrivate: false
      },
      newVault: {
        name: "",
        description: ""
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
        img: "",
        isPrivate: false
      };
    },
    makeVault() {
      let vault = this.newVault;
      this.$store.dispatch("makeVault", vault);
      this.newVault = {
        name: "",
        description: ""
      };
    }
  },
  components: {
    Keep
  }
};
</script>

<style></style>
