<template>
  <div class="dashboard container-fluid bg-img pt-3">
    <div class="row">
      <div class="col">
        <h1>WELCOME TO THE DASHBOARD</h1>
      </div>
    </div>
    <!-- <div class="row">
      <div class="col">
        <div class="card-columns" v-if="publicKeeps.length > 0">
          <keep
            v-for="keep in publicKeeps"
            :key="keep.id"
            :keepData="keep"
          ></keep>
        </div>
      </div>
    </div>-->
    <hr />
    <div class="row">
      <div class="col">
        <h3>Mine. All mine.</h3>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <div class="card-columns" v-if="userKeeps.length > 0">
          <keep v-for="keep in userKeeps" :key="keep.id" :keepData="keep"></keep>
        </div>
      </div>
    </div>
    <hr />
    <div class="row">
      <div class="col">
        <h3>Vaults</h3>
      </div>
    </div>
    <div class="row">
      <div class="col d-flex" v-if="vaults.length > 0">
        <vault class="d-inline" v-for="vault in vaults" :key="vault.id" :vaultData="vault"></vault>
      </div>
    </div>
    <hr />
    <div class="row">
      <div class="col">
        <h4>Add New Keep</h4>
        <form @submit.prevent="createKeep">
          <input type="text" id="keep-name" placeholder="Title" v-model="newKeep.name" required />
          <input
            type="text"
            id="keep-description"
            placeholder="Description"
            v-model="newKeep.description"
            required
          />
          <input type="text" id="keep-img" placeholder="Image Url" v-model="newKeep.img" required />
          <input type="checkbox" name="isPrivate" id="isPrivate" v-model="newKeep.isPrivate" />
          <label for="isPrivate">private</label>
          <button type="submit">Add</button>
        </form>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <h4>Add New Vault</h4>
        <form @submit.prevent="makeVault">
          <input type="text" id="vault-name" placeholder="Title" v-model="newVault.name" required />
          <input
            type="text"
            id="vault-description"
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
import Vault from "../components/Vault";

export default {
  name: "dashboard",
  mounted() {
    this.$store.dispatch("getKeeps");
    this.$store.dispatch("getVaults");
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
    // publicKeeps() {
    //   return (
    //     this.$store.state.publicKeeps || {
    //       title: "Loading..."
    //     }
    //   );
    // },
    userKeeps() {
      return this.$store.state.userKeeps;
    },
    vaults() {
      return this.$store.state.vaults;
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
    Keep,
    Vault
  }
};
</script>

<style>
.bg-img {
  background-image: url("https://images.unsplash.com/photo-1546801226-104a8000e041?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1050&q=80");
  background-attachment: fixed;
}
body {
  font-family: "Limelight", cursive;
}
</style>
