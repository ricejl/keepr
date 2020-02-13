<template>
  <div class="vault">
    <div class="card-columns" v-show="keeps.length > 0">
      <keep v-for="keep in keeps" :key="keep.id" :keepData="keep"></keep>
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
  },
  params: ["vaultId"],
  computed: {
    keeps() {
      return this.$store.state.activeVault;
    }
  },
  components: { Keep }
};
</script>

<style></style>
