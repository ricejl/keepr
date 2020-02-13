<template>
  <div class="vault"></div>
</template>

<script>
export default {
  name: "vault",
  mounted() {
    this.$store.dispatch("getKeepsByVaultId", this.$route.params.id);
  },
  computed: {
    keeps() {
      return this.$store.state.activeVault;
    }
  }
};
</script>

<style></style>
