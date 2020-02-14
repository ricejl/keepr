<template>
  <div class="vault-component">
    <div class="card" style="width: 10rem;">
      <router-link :to="{ name: 'vault', params: { vaultId: vaultData.id } }">
        <img
          src="https://sfbeerweek.org/upload/e3fd652ba506415d/menageriesmall2.jpg"
          class="card-img-top"
          alt="vault-image"
        />
      </router-link>
      <div class="card-body bg-light text-center">
        {{ vaultData.name }}
        <i
          class="far fa-times-circle delete-vault"
          title="delete"
          @click="deleteVault(vaultData.id)"
        ></i>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "vault-component",
  mounted() {},
  props: ["vaultData"],
  methods: {
    deleteVault(id) {
      this.$store.dispatch("deleteVault", id);
    }
  }
};
</script>

<style>
.card-body {
  position: relative;
}
.delete-vault {
  position: absolute;
  top: 0.3em;
  right: 0.3em;
  cursor: pointer;
}
</style>
