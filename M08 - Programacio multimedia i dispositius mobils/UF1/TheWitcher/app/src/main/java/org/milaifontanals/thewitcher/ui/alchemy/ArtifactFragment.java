package org.milaifontanals.thewitcher.ui.alchemy;

import android.content.Context;
import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import org.milaifontanals.thewitcher.MainActivity;
import org.milaifontanals.thewitcher.R;
import org.milaifontanals.thewitcher.adapters.ArtifactAdapter;
import org.milaifontanals.thewitcher.databinding.FragmentArtifactBinding;
import org.milaifontanals.thewitcher.model.Artifact;
import org.milaifontanals.thewitcher.viewmodel.ArtifactViewModel;

public class ArtifactFragment extends Fragment implements ArtifactAdapter.ArtifactAdapterListener {

    private ArtifactViewModel artifactViewModel;
    private ArtifactAdapter artifactAdapter;
    private FragmentArtifactBinding binding;

    public ArtifactFragment() {
    }

    public static ArtifactFragment newInstance() {
        return new ArtifactFragment();
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        artifactViewModel =new ViewModelProvider(getActivity()).get(ArtifactViewModel.class);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding=FragmentArtifactBinding.inflate(inflater,container,false);
        return binding.getRoot();
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        binding.setViewmodel(artifactViewModel);
        binding.setLifecycleOwner(this);

        artifactViewModel.updateData(Artifact.BOMBS);

        binding.btnBombs.setOnClickListener(view1 -> artifactViewModel.updateData(Artifact.BOMBS));
        binding.btnOils.setOnClickListener(view1 -> artifactViewModel.updateData(Artifact.OILS));
        binding.btnPotions.setOnClickListener(view1 -> artifactViewModel.updateData(Artifact.POTIONS));

        artifactViewModel.getArtifacts().observe(getViewLifecycleOwner(), artifacts -> {
            Log.d("TWInfo","This is loading");
            artifactAdapter=new ArtifactAdapter(requireContext(),artifacts,this);
            binding.rcyArtifacts.setAdapter(artifactAdapter);
        });

        binding.rcyArtifacts.setHasFixedSize(true);
        binding.rcyArtifacts.setLayoutManager(new LinearLayoutManager(requireContext(), RecyclerView.VERTICAL,false));

        binding.txtReturn.setOnClickListener(view1 -> {
            Intent intent = new Intent(requireContext(), MainActivity.class);
            startActivity(intent);
        });
    }

    @Override
    public void onArtifactSelected(Artifact artifact) {
        requireActivity().setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE);
        getParentFragmentManager().beginTransaction()
                .setCustomAnimations(
                        android.R.anim.slide_in_left,
                        android.R.anim.slide_out_right,
                        android.R.anim.slide_in_left,
                        android.R.anim.slide_out_right
                )
                .replace(R.id.container,EditorFragment.newInstance(artifact.id))
                .addToBackStack(null)
                .commit();
    }
}