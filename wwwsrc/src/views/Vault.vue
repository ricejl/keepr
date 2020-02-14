<template>
  <div class="vault container-fluid bg-img pt-3">
    <div class="row">
      <div class="col">
        <h3>{{activeVault.name}}</h3>
        <h5>{{activeVault.description}}</h5>
        <hr />
        <div class="card-columns" v-show="keeps.length > 0">
          <keep v-for="keep in keeps" :key="keep.id" :keepData="keep"></keep>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Keep from "@/components/Keep";
export default {
  name: "vault",
  mounted() {
    this.$store.dispatch("getKeepsByVaultId", this.$route.params.vaultId);
    // FIXME this fails on pg refresh. vaultid is undefined
    this.$store.dispatch("getVaultById", this.$route.params.vaultId);
  },
  params: ["vaultId"],
  computed: {
    keeps() {
      return this.$store.state.keepsInActiveVault;
    },
    activeVault() {
      return this.$store.state.activeVault;
    }
  },
  components: { Keep }
};
</script>

<style>
.bg-img {
  background-image: url("https://images.unsplash.com/photo-1546801226-104a8000e041?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1050&q=80");
  background-attachment: fixed;
}
</style>
