﻿using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using CoreLocation;
using Google.Maps;

namespace Google.Places
{
	// @interface GMSAddressComponent : NSObject
	[BaseType (typeof (NSObject), Name = "GMSAddressComponent")]
	interface AddressComponent
	{
		// @property(nonatomic, readonly, copy) NSString *type;
		[Export ("type")]
		string Type { get; }

		// @property(nonatomic, readonly, copy) NSString *name;
		[Export ("name")]
		string Name { get; }
	}

	interface IAutocompleteFetcherDelegate
	{
	}

	// @protocol GMSAutocompleteFetcherDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GMSAutocompleteFetcherDelegate")]
	interface AutocompleteFetcherDelegate
	{
		// - (void)didAutocompleteWithPredictions:(NSArray *)predictions;
		[Abstract]
		[Export ("didAutocompleteWithPredictions:")]
		void DidAutocomplete (AutocompletePrediction [] predictions);

		// - (void)didFailAutocompleteWithError:(NSError *)error;
		[Abstract]
		[Export ("didFailAutocompleteWithError:")]
		void DidFailAutocomplete (NSError error);
	}

	// @interface GMSAutocompleteFetcher : NSObject
	[BaseType (typeof (NSObject), Name = "GMSAutocompleteFetcher")]
	interface AutocompleteFetcher
	{
		// - (instancetype)initWithBounds:(GMSCoordinateBounds * GMS_NULLABLE_PTR)bounds filter:(GMSAutocompleteFilter * GMS_NULLABLE_PTR)filter;
		[Export ("initWithBounds:filter:")]
		IntPtr Constructor ([NullAllowed] Google.Maps.CoordinateBounds bounds, [NullAllowed] AutocompleteFilter filter);

		// @property(nonatomic, weak) id<GMSAutocompleteFetcherDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IAutocompleteFetcherDelegate Delegate { get; set; }

		// @property(nonatomic, strong) GMSCoordinateBounds *autocompleteBounds;
		[NullAllowed]
		[Export ("autocompleteBounds", ArgumentSemantic.Strong)]
		Google.Maps.CoordinateBounds AutocompleteBounds { get; set; }

		// @property (assign, nonatomic) GMSAutocompleteBoundsMode autocompleteBoundsMode;
		[Export("autocompleteBoundsMode", ArgumentSemantic.Assign)]
		AutocompleteBoundsMode AutocompleteBoundsMode { get; set; }

		// @property(nonatomic, strong) GMSAutocompleteFilter *autocompleteFilter;
		[NullAllowed]
		[Export ("autocompleteFilter", ArgumentSemantic.Strong)]
		AutocompleteFilter AutocompleteFilter { get; set; }

		// - (void)sourceTextHasChanged:(NSString *)text;
		[Export ("sourceTextHasChanged:")]
		void SourceTextHasChanged ([NullAllowed] string text);
	}

	// @interface GMSAutocompleteFilter : NSObject
	[BaseType (typeof (NSObject), Name = "GMSAutocompleteFilter")]
	interface AutocompleteFilter
	{
		// @property (assign, nonatomic) GMSPlacesAutocompleteTypeFilter type;
		[Export ("type", ArgumentSemantic.Assign)]
		PlacesAutocompleteTypeFilter Type { get; set; }

		// @property(nonatomic, copy) NSString *country;
		[NullAllowed]
		[Export ("country", ArgumentSemantic.Copy)]
		string Country { get; set; }
	}

	// @interface GMSAutocompleteMatchFragment : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSAutocompleteMatchFragment")]
	interface AutocompleteMatchFragment
	{
		// @property (readonly, nonatomic) NSUInteger offset;
		[Export ("offset")]
		nuint Offset { get; }

		// @property (readonly, nonatomic) NSUInteger length;
		[Export ("length")]
		nuint Length { get; }
	}

	// @interface GMSAutocompletePrediction : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSAutocompletePrediction")]
	interface AutocompletePrediction
	{
		// extern NSString *const _Nonnull kGMSAutocompleteMatchAttribute;
		[Field ("kGMSAutocompleteMatchAttribute", "__Internal")]
		NSString AutocompleteMatchAttribute { get; }

		// @property (readonly, copy, nonatomic) NSAttributedString * attributedFullText;
		[Export ("attributedFullText", ArgumentSemantic.Copy)]
		NSAttributedString AttributedFullText { get; }

		// @property(nonatomic, copy, readonly) NSAttributedString *attributedPrimaryText;
		[Export ("attributedPrimaryText", ArgumentSemantic.Copy)]
		NSAttributedString AttributedPrimaryText { get; }

		// @property(nonatomic, copy, readonly) NSAttributedString *attributedSecondaryText;
		[Export ("attributedSecondaryText", ArgumentSemantic.Copy)]
		NSAttributedString AttributedSecondaryText { get; }

		// @property (readonly, copy, nonatomic) NSString * placeID;
		[Export ("placeID", ArgumentSemantic.Copy)]
		string PlaceId { get; }

		// @property (readonly, copy, nonatomic) NSArray * types;
		[Export ("types", ArgumentSemantic.Copy)]
		string [] Types { get; }
	}

	interface IAutocompleteResultsViewControllerDelegate
	{
	}

	// @protocol GMSAutocompleteResultsViewControllerDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GMSAutocompleteResultsViewControllerDelegate")]
	interface AutocompleteResultsViewControllerDelegate
	{
		// @required - (void)resultsController:(GMSAutocompleteResultsViewController *)resultsController didAutocompleteWithPlace:(GMSPlace *)place;
		[Abstract]
		[EventArgs ("AutocompleteResultsViewControllerAutocompleted")]
		[EventName ("Autocompleted")]
		[Export ("resultsController:didAutocompleteWithPlace:")]
		void DidAutocomplete (AutocompleteResultsViewController resultsController, Place place);

		// @required - (void)resultsController:(GMSAutocompleteResultsViewController *)resultsController didFailAutocompleteWithError:(NSError *)error;
		[Abstract]
		[EventArgs ("AutocompleteResultsViewControllerAutocompleteFailed")]
		[EventName ("AutocompleteFailed")]
		[Export ("resultsController:didFailAutocompleteWithError:")]
		void DidFailAutocomplete (AutocompleteResultsViewController resultsController, NSError error);

		// @optional - (BOOL)resultsController:(GMSAutocompleteResultsViewController *)resultsController didSelectPrediction:(GMSAutocompletePrediction *)prediction;
		[DefaultValue (true)]
		[DelegateName ("AutocompleteResultsViewControllerPredictionSelected")]
		[Export ("resultsController:didSelectPrediction:")]
		bool DidSelectPrediction (AutocompleteResultsViewController resultsController, AutocompletePrediction prediction);

		// @optional - (void)didUpdateAutocompletePredictionsForResultsController:(GMSAutocompleteResultsViewController *)resultsController;
		[EventArgs ("AutocompleteResultsViewControllerAutocompletePredictionsUpdated")]
		[EventName ("AutocompletePredictionsUpdated")]
		[Export ("didUpdateAutocompletePredictionsForResultsController:")]
		void DidUpdateAutocompletePredictions (AutocompleteResultsViewController resultsController);

		// @optional - (void)didRequestAutocompletePredictionsForResultsController:(GMSAutocompleteResultsViewController *)resultsController;
		[EventArgs ("AutocompleteResultsViewControllerAutocompletePredictionsRequested")]
		[EventName ("AutocompletePredictionsRequested")]
		[Export ("didRequestAutocompletePredictionsForResultsController:")]
		void DidRequestAutocompletePredictions (AutocompleteResultsViewController resultsController);
	}

	// @interface GMSAutocompleteResultsViewController : UIViewController <UISearchResultsUpdating>
	[BaseType (typeof (UIViewController),
		Name = "GMSAutocompleteResultsViewController",
		Delegates = new string [] { "Delegate" },
		Events = new Type [] { typeof (AutocompleteResultsViewControllerDelegate) })]
	interface AutocompleteResultsViewController : IUISearchResultsUpdating
	{
		// @property(nonatomic, weak) id<GMSAutocompleteResultsViewControllerDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IAutocompleteResultsViewControllerDelegate Delegate { get; set; }

		// @property(nonatomic, strong) GMSCoordinateBounds *autocompleteBounds;
		[NullAllowed]
		[Export ("autocompleteBounds", ArgumentSemantic.Strong)]
		Google.Maps.CoordinateBounds AutocompleteBounds { get; set; }

		// @property (assign, nonatomic) GMSAutocompleteBoundsMode autocompleteBoundsMode;
		[Export("autocompleteBoundsMode", ArgumentSemantic.Assign)]
		AutocompleteBoundsMode AutocompleteBoundsMode { get; set; }

		// @property(nonatomic, strong) GMSAutocompleteFilter *autocompleteFilter;
		[NullAllowed]
		[Export ("autocompleteFilter", ArgumentSemantic.Strong)]
		AutocompleteFilter AutocompleteFilter { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *tableCellBackgroundColor;
		[Export ("tableCellBackgroundColor", ArgumentSemantic.Strong)]
		UIColor TableCellBackgroundColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *tableCellSeparatorColor;
		[Export ("tableCellSeparatorColor", ArgumentSemantic.Strong)]
		UIColor TableCellSeparatorColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *primaryTextColor;
		[Export ("primaryTextColor", ArgumentSemantic.Strong)]
		UIColor PrimaryTextColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *primaryTextHighlightColor;
		[Export ("primaryTextHighlightColor", ArgumentSemantic.Strong)]
		UIColor PrimaryTextHighlightColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *secondaryTextColor;
		[Export ("secondaryTextColor", ArgumentSemantic.Strong)]
		UIColor SecondaryTextColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *GMS_NULLABLE_PTR tintColor;
		[NullAllowed]
		[Export ("tintColor", ArgumentSemantic.Strong)]
		UIColor TintColor { get; set; }
	}

	interface IAutocompleteTableDataSourceDelegate
	{
	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GMSAutocompleteTableDataSourceDelegate")]
	interface AutocompleteTableDataSourceDelegate
	{
		// @required - (void)tableDataSource:(GMSAutocompleteTableDataSource *)tableDataSource didAutocompleteWithPlace:(GMSPlace *)place;
		[Abstract]
		[EventArgs ("AutocompleteTableDataSourceAutocompleted")]
		[EventName ("Autocompleted")]
		[Export ("tableDataSource:didAutocompleteWithPlace:")]
		void DidAutocomplete (AutocompleteTableDataSource tableDataSource, Place place);

		// @required - (void)tableDataSource:(GMSAutocompleteTableDataSource *)tableDataSource didFailAutocompleteWithError:(NSError *)error;
		[Abstract]
		[EventArgs ("AutocompleteTableDataSourceAutocompleteFailed")]
		[EventName ("AutocompleteFailed")]
		[Export ("tableDataSource:didFailAutocompleteWithError:")]
		void DidFailAutocomplete (AutocompleteTableDataSource tableDataSource, NSError error);

		// @optional - (BOOL)tableDataSource:(GMSAutocompleteTableDataSource *)tableDataSource didSelectPrediction:(GMSAutocompletePrediction *)prediction;
		[DefaultValue (true)]
		[DelegateName ("AutocompleteTableDataSourcePredictionSelected")]
		[Export ("tableDataSource:didSelectPrediction:")]
		bool DidSelectPrediction (AutocompleteTableDataSource tableDataSource, AutocompletePrediction prediction);

		// @optional - (void)didUpdateAutocompletePredictionsForTableDataSource: (GMSAutocompleteTableDataSource *)tableDataSource;
		[EventArgs ("AutocompleteTableDataSourceAutocompletePredictionsUpdated")]
		[EventName ("AutocompletePredictionsUpdated")]
		[Export ("didUpdateAutocompletePredictionsForTableDataSource:")]
		void DidUpdateAutocompletePredictions (AutocompleteTableDataSource tableDataSource);

		// @optional - (void)didRequestAutocompletePredictionsForTableDataSource:(GMSAutocompleteTableDataSource *)tableDataSource;
		[EventArgs ("AutocompleteTableDataSourceAutocompletePredictionsRequested")]
		[EventName ("AutocompletePredictionsRequested")]
		[Export ("didRequestAutocompletePredictionsForTableDataSource:")]
		void DidRequestAutocompletePredictions (AutocompleteTableDataSource tableDataSource);
	}

	// @interface GMSAutocompleteTableDataSource : NSObject <UITableViewDataSource, UITableViewDelegate>
	[BaseType (typeof (NSObject),
		Name = "GMSAutocompleteTableDataSource",
		Delegates = new string [] { "Delegate" },
		Events = new Type [] { typeof (AutocompleteTableDataSourceDelegate) })]
	interface AutocompleteTableDataSource : IUITableViewDataSource, IUITableViewDelegate
	{
		// @property(nonatomic, weak) IBOutlet id<GMSAutocompleteTableDataSourceDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IAutocompleteTableDataSourceDelegate Delegate { get; set; }

		// @property(nonatomic, strong) GMSCoordinateBounds *autocompleteBounds;
		[NullAllowed]
		[Export ("autocompleteBounds", ArgumentSemantic.Strong)]
		Google.Maps.CoordinateBounds AutocompleteBounds { get; set; }

		// @property (assign, nonatomic) GMSAutocompleteBoundsMode autocompleteBoundsMode;
		[Export("autocompleteBoundsMode", ArgumentSemantic.Assign)]
		AutocompleteBoundsMode AutocompleteBoundsMode { get; set; }

		// @property(nonatomic, strong) GMSAutocompleteFilter *autocompleteFilter;
		[NullAllowed]
		[Export ("autocompleteFilter", ArgumentSemantic.Strong)]
		AutocompleteFilter AutocompleteFilter { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *tableCellBackgroundColor;
		[Export ("tableCellBackgroundColor", ArgumentSemantic.Strong)]
		UIColor TableCellBackgroundColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *tableCellSeparatorColor;
		[Export ("tableCellSeparatorColor", ArgumentSemantic.Strong)]
		UIColor TableCellSeparatorColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *primaryTextColor;
		[Export ("primaryTextColor", ArgumentSemantic.Strong)]
		UIColor PrimaryTextColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *primaryTextHighlightColor;
		[Export ("primaryTextHighlightColor", ArgumentSemantic.Strong)]
		UIColor PrimaryTextHighlightColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *secondaryTextColor;
		[Export ("secondaryTextColor", ArgumentSemantic.Strong)]
		UIColor SecondaryTextColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *GMS_NULLABLE_PTR tintColor;
		[NullAllowed]
		[Export ("tintColor", ArgumentSemantic.Strong)]
		UIColor TintColor { get; set; }

		// - (void)sourceTextHasChanged:(NSString *)text;
		[Export ("sourceTextHasChanged:")]
		void SourceTextHasChanged ([NullAllowed] string text);
	}

	interface IAutocompleteViewControllerDelegate
	{
	}

	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GMSAutocompleteViewControllerDelegate")]
	interface AutocompleteViewControllerDelegate
	{
		// @required - (void)viewController:(GMSAutocompleteViewController *)viewController didAutocompleteWithPlace:(GMSPlace *)place;
		[Abstract]
		[EventArgs ("AutocompleteViewControllerAutocompleted")]
		[EventName ("Autocompleted")]
		[Export ("viewController:didAutocompleteWithPlace:")]
		void DidAutocomplete (AutocompleteViewController viewController, Place place);

		// @required - (void)viewController:(GMSAutocompleteViewController *)viewController didFailAutocompleteWithError:(NSError *)error;
		[Abstract]
		[EventArgs ("AutocompleteViewControllerAutocompleteFailed")]
		[EventName ("AutocompleteFailed")]
		[Export ("viewController:didFailAutocompleteWithError:")]
		void DidFailAutocomplete (AutocompleteViewController viewController, NSError error);

		// @required - (void)wasCancelled:(GMSAutocompleteViewController *)viewController;
		[Abstract]
		[EventArgs ("AutocompleteViewControllerWasCancelled")]
		[Export ("wasCancelled:")]
		void WasCancelled (AutocompleteViewController viewController);

		// @optional - (BOOL)viewController:(GMSAutocompleteViewController *)viewController didSelectPrediction:(GMSAutocompletePrediction *)prediction;
		[DefaultValue (true)]
		[DelegateName ("AutocompleteViewControllerPredictionSelected")]
		[Export ("viewController:didSelectPrediction:")]
		bool DidSelectPrediction (AutocompleteViewController viewController, AutocompletePrediction prediction);

		// @optional - (void)didUpdateAutocompletePredictions:(GMSAutocompleteViewController *)viewController;
		[EventArgs ("AutocompleteViewControllerAutocompletePredictionsUpdated")]
		[EventName ("AutocompletePredictionsUpdated")]
		[Export ("didUpdateAutocompletePredictions:")]
		void DidUpdateAutocompletePredictions (AutocompleteViewController viewController);

		// @optional - (void)didRequestAutocompletePredictions:(GMSAutocompleteViewController *)viewController;
		[EventArgs ("AutocompleteViewControllerPredictionsRequested")]
		[EventName ("AutocompletePredictionsRequested")]
		[Export ("didRequestAutocompletePredictions:")]
		void DidRequestAutocompletePredictions (AutocompleteViewController viewController);
	}

	// @interface GMSAutocompleteViewController : UIViewController
	[BaseType (typeof (UIViewController),
	           Name = "GMSAutocompleteViewController",
		   Delegates = new string [] { "Delegate" },
	           Events = new Type [] { typeof (AutocompleteViewControllerDelegate) })]
	interface AutocompleteViewController
	{
		// @property(nonatomic, weak) IBOutlet id<GMSAutocompleteViewControllerDelegate> delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IAutocompleteViewControllerDelegate Delegate { get; set; }

		// @property(nonatomic, strong) GMSCoordinateBounds *autocompleteBounds;
		[NullAllowed]
		[Export ("autocompleteBounds", ArgumentSemantic.Strong)]
		Google.Maps.CoordinateBounds AutocompleteBounds { get; set; }

		// @property (assign, nonatomic) GMSAutocompleteBoundsMode autocompleteBoundsMode;
		[Export("autocompleteBoundsMode", ArgumentSemantic.Assign)]
		AutocompleteBoundsMode AutocompleteBoundsMode { get; set; }

		// @property(nonatomic, strong) GMSAutocompleteFilter *autocompleteFilter;
		[NullAllowed]
		[Export ("autocompleteFilter", ArgumentSemantic.Strong)]
		AutocompleteFilter AutocompleteFilter { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *tableCellBackgroundColor;
		[Export ("tableCellBackgroundColor", ArgumentSemantic.Strong)]
		UIColor TableCellBackgroundColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *tableCellSeparatorColor;
		[Export ("tableCellSeparatorColor", ArgumentSemantic.Strong)]
		UIColor TableCellSeparatorColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *primaryTextColor;
		[Export ("primaryTextColor", ArgumentSemantic.Strong)]
		UIColor PrimaryTextColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *primaryTextHighlightColor;
		[Export ("primaryTextHighlightColor", ArgumentSemantic.Strong)]
		UIColor PrimaryTextHighlightColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *secondaryTextColor;
		[Export ("secondaryTextColor", ArgumentSemantic.Strong)]
		UIColor SecondaryTextColor { get; set; }

		// @property(nonatomic, strong) IBInspectable UIColor *GMS_NULLABLE_PTR tintColor;
		[NullAllowed]
		[Export ("tintColor", ArgumentSemantic.Strong)]
		UIColor TintColor { get; set; }
	}

	// @interface GMSPlace : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSPlace")]
	interface Place
	{
		// @property (readonly, copy, nonatomic) NSString * name;
		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSString * placeID;
		[Export ("placeID", ArgumentSemantic.Copy)]
		string Id { get; }

		// @property (readonly, nonatomic) CLLocationCoordinate2D coordinate;
		[Export ("coordinate", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Coordinate { get; }

		// @property (readonly, nonatomic) GMSPlacesOpenNowStatus openNowStatus;
		[Export ("openNowStatus", ArgumentSemantic.Assign)]
		PlacesOpenNowStatus OpenNowStatus { get; }

		// @property (readonly, copy, nonatomic) NSString * phoneNumber;
		[NullAllowed]
		[Export ("phoneNumber", ArgumentSemantic.Copy)]
		string PhoneNumber { get; }

		// @property (readonly, copy, nonatomic) NSString * formattedAddress;
		[NullAllowed]
		[Export ("formattedAddress", ArgumentSemantic.Copy)]
		string FormattedAddress { get; }

		// @property (readonly, nonatomic) float rating;
		[Export ("rating", ArgumentSemantic.Assign)]
		float Rating { get; }

		// @property (readonly, nonatomic) GMSPlacesPriceLevel priceLevel;
		[Export ("priceLevel", ArgumentSemantic.Assign)]
		PlacesPriceLevel PriceLevel { get; }

		// @property (readonly, copy, nonatomic) NSArray * types;
		[NullAllowed]
		[Export ("types", ArgumentSemantic.Copy)]
		string [] Types { get; }

		// @property (readonly, copy, nonatomic) NSURL * website;
		[NullAllowed]
		[Export ("website", ArgumentSemantic.Copy)]
		NSUrl Website { get; }

		// @property (readonly, copy, nonatomic) NSAttributedString * attributions;
		[NullAllowed]
		[Export ("attributions", ArgumentSemantic.Copy)]
		NSAttributedString Attributions { get; }

		// @property(nonatomic, strong, readonly) GMSCoordinateBounds *viewport;
		[NullAllowed]
		[Export ("viewport", ArgumentSemantic.Strong)]
		Google.Maps.CoordinateBounds Viewport { get; }

		// @property(nonatomic, copy, readonly) GMS_NSArrayOf(GMSAddressComponent *) *GMS_NULLABLE_PTR addressComponents;
		[NullAllowed]
		[Export ("addressComponents", ArgumentSemantic.Copy)]
		AddressComponent [] AddressComponents { get; }
	}

	// @interface GMSPlaceLikelihood : NSObject <NSCopying>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSPlaceLikelihood")]
	interface PlaceLikelihood : INSCopying
	{
		// @property (readonly, nonatomic, strong) GMSPlace * place;
		[Export ("place", ArgumentSemantic.Strong)]
		Place Place { get; }

		// @property (readonly, assign, nonatomic) double likelihood;
		[Export ("likelihood")]
		double Likelihood { get; }

		// -(instancetype)initWithPlace:(GMSPlace *)place likelihood:(double)likelihood;
		[Export ("initWithPlace:likelihood:")]
		IntPtr Constructor (Place place, double likelihood);
	}

	// @interface GMSPlaceLikelihoodList : NSObject
	[BaseType (typeof (NSObject), Name = "GMSPlaceLikelihoodList")]
	interface PlaceLikelihoodList
	{
		// @property (copy, nonatomic) NSArray * likelihoods;
		[Export ("likelihoods", ArgumentSemantic.Copy)]
		PlaceLikelihood [] Likelihoods { get; set; }

		// @property (readonly, copy, nonatomic) NSAttributedString * attributions;
		[NullAllowed]
		[Export ("attributions", ArgumentSemantic.Copy)]
		NSAttributedString Attributions { get; }
	}

	// @interface GMSPlacePhotoMetadata : NSObject
	[BaseType (typeof (NSObject), Name = "GMSPlacePhotoMetadata")]
	interface PlacePhotoMetadata
	{
		// @property(nonatomic, readonly, copy) NSAttributedString* GMS_NULLABLE_PTR attributions;
		[NullAllowed]
		[Export ("attributions", ArgumentSemantic.Copy)]
		NSAttributedString Attributions { get; }

		// @property(nonatomic, readonly, assign) CGSize maxSize;
		[Export ("maxSize", ArgumentSemantic.Assign)]
		CGSize MaxSize { get; }
	}

	// @interface GMSPlacePhotoMetadataList : NSObject
	[BaseType (typeof (NSObject), Name = "GMSPlacePhotoMetadataList")]
	interface PlacePhotoMetadataList
	{
		// @property(nonatomic, readonly, copy) GMS_NSArrayOf(GMSPlacePhotoMetadata *) * results;
		[Export ("results", ArgumentSemantic.Copy)]
		PlacePhotoMetadata [] Results { get; }
	}

	// typedef void (^GMSPlaceResultCallback)(GMSPlace *NSError *);
	delegate void PlaceResultHandler ([NullAllowed] Place result, [NullAllowed] NSError error);

	// typedef void (^GMSPlaceLikelihoodListCallback)(GMSPlaceLikelihoodList *NSError *);
	delegate void PlaceLikelihoodListHandler ([NullAllowed] PlaceLikelihoodList likelihoodList, [NullAllowed] NSError error);

	// typedef void (^GMSAutocompletePredictionsCallback)(NSArray *NSError *);
	delegate void AutocompletePredictionsHandler ([NullAllowed] AutocompletePrediction [] results, [NullAllowed] NSError error);

	// typedef void (^GMSPlacePhotoMetadataResultCallback)(GMSPlacePhotoMetadataList *GMS_NULLABLE_PTR photos, NSError *GMS_NULLABLE_PTR error);
	delegate void PlacePhotoMetadataResultHandler ([NullAllowed] PlacePhotoMetadataList photos, [NullAllowed] NSError error);

	// typedef void (^GMSPlacePhotoImageResultCallback)(UIImage *GMS_NULLABLE_PTR photo, NSError *GMS_NULLABLE_PTR error);
	delegate void PlacePhotoImageResultHandler ([NullAllowed] UIImage photo, [NullAllowed] NSError error);

	// @interface GMSPlacesClient : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSPlacesClient")]
	interface PlacesClient
	{
		// extern NSString *const _Nonnull kGMSPlacesErrorDomain;
		[Field ("kGMSPlacesErrorDomain", "__Internal")]
		NSString PlacesErrorDomain { get; }

		// +(instancetype)sharedClient;
		[Static]
		[Export ("sharedClient")]
		PlacesClient SharedInstance { get; }

		// + (BOOL)provideAPIKey:(NSString *)key;
		[Static]
		[Export ("provideAPIKey:")]
		bool ProvideApiKey (string key);

		// + (NSString *)openSourceLicenseInfo;
		[Static]
		[Export ("openSourceLicenseInfo")]
		string OpenSourceLicenseInfo { get; }

		// + (NSString *)SDKVersion;
		[Static]
		[Export ("SDKVersion")]
		string SdkVersion { get; }

		// -(void)reportDeviceAtPlaceWithID:(NSString *)placeID;
		[Export ("reportDeviceAtPlaceWithID:")]
		void ReportDeviceAtPlace (string placeId);

		// -(void)lookUpPlaceID:(NSString *)placeID callback:(GMSPlaceResultCallback)callback;
		[Export ("lookUpPlaceID:callback:")]
		void LookUpPlaceId (string placeId, PlaceResultHandler callback);

		// - (void)lookUpPhotosForPlaceID:(NSString *)placeID callback:(GMSPlacePhotoMetadataResultCallback)callback;
		[Export ("lookUpPhotosForPlaceID:callback:")]
		void LookUpPhotos (string placeId, PlacePhotoMetadataResultHandler callback);

		// - (void)loadPlacePhoto:(GMSPlacePhotoMetadata *)photo callback:(GMSPlacePhotoImageResultCallback)callback;
		[Export ("loadPlacePhoto:callback:")]
		void LoadPlacePhoto (PlacePhotoMetadata photo, PlacePhotoImageResultHandler callback);

		// - (void)loadPlacePhoto:(GMSPlacePhotoMetadata *)photo constrainedToSize:(CGSize)maxSize scale:(CGFloat)scale callback:(GMSPlacePhotoImageResultCallback)callback;
		[Export ("loadPlacePhoto:constrainedToSize:scale:callback:")]
		void LoadPlacePhoto (PlacePhotoMetadata photo, CGSize maxSize, nfloat scale, PlacePhotoImageResultHandler callback);

		// -(void)currentPlaceWithCallback:(GMSPlaceLikelihoodListCallback)callback;
		[Export ("currentPlaceWithCallback:")]
		void CurrentPlace (PlaceLikelihoodListHandler callback);

		// -(void)autocompleteQuery:(NSString *)query bounds:(GMSCoordinateBounds *)bounds filter:(GMSAutocompleteFilter *)filter callback:(GMSAutocompletePredictionsCallback)callback;
		[Export ("autocompleteQuery:bounds:filter:callback:")]
		void Autocomplete (string query, [NullAllowed] Google.Maps.CoordinateBounds bounds, [NullAllowed] AutocompleteFilter filter, AutocompletePredictionsHandler callback);

		// -(void)autocompleteQuery:(NSString * _Nonnull)query bounds:(GMSCoordinateBounds * _Nullable)bounds boundsMode:(GMSAutocompleteBoundsMode)boundsMode filter:(GMSAutocompleteFilter * _Nullable)filter callback:(GMSAutocompletePredictionsCallback _Nonnull)callback;
		[Export("autocompleteQuery:bounds:boundsMode:filter:callback:")]
		void Autocomplete(string query, [NullAllowed] CoordinateBounds bounds, AutocompleteBoundsMode boundsMode, [NullAllowed] AutocompleteFilter filter, AutocompletePredictionsHandler callback);

		// -(void)addPlace:(GMSUserAddedPlace *)place callback:(GMSPlaceResultCallback)callback;
		[Obsolete ("The Add Place feature is deprecated as of June 30, 2017. This feature will be turned down on June 30, 2018, and will no longer be available after that date.")]
		[Export ("addPlace:callback:")]
		void AddPlace (UserAddedPlace place, PlaceResultHandler callback);
	}

	[Static]
	interface PlaceTypes
	{
		// -(NSString *)kGMSPlaceTypeAccountingExported;
		[Field ("kGMSPlaceTypeAccounting", "__Internal")]
		NSString Accounting { get; }

		// -(NSString *)kGMSPlaceTypeAdministrativeAreaLevel1Exported;
		[Field ("kGMSPlaceTypeAdministrativeAreaLevel1", "__Internal")]
		NSString AdministrativeAreaLevel1 { get; }

		// -(NSString *)kGMSPlaceTypeAdministrativeAreaLevel2Exported;
		[Field ("kGMSPlaceTypeAdministrativeAreaLevel2", "__Internal")]
		NSString AdministrativeAreaLevel2 { get; }

		// -(NSString *)kGMSPlaceTypeAdministrativeAreaLevel3Exported;
		[Field ("kGMSPlaceTypeAdministrativeAreaLevel3", "__Internal")]
		NSString AdministrativeAreaLevel3 { get; }

		// -(NSString *)kGMSPlaceTypeAirportExported;
		[Field ("kGMSPlaceTypeAirport", "__Internal")]
		NSString Airport { get; }

		// -(NSString *)kGMSPlaceTypeAmusementParkExported;
		[Field ("kGMSPlaceTypeAmusementPark", "__Internal")]
		NSString AmusementPark { get; }

		// -(NSString *)kGMSPlaceTypeAquariumExported;
		[Field ("kGMSPlaceTypeAquarium", "__Internal")]
		NSString Aquarium { get; }

		// -(NSString *)kGMSPlaceTypeArtGalleryExported;
		[Field ("kGMSPlaceTypeArtGallery", "__Internal")]
		NSString ArtGallery { get; }

		// -(NSString *)kGMSPlaceTypeAtmExported;
		[Field ("kGMSPlaceTypeAtm", "__Internal")]
		NSString Atm { get; }

		// -(NSString *)kGMSPlaceTypeBakeryExported;
		[Field ("kGMSPlaceTypeBakery", "__Internal")]
		NSString Bakery { get; }

		// -(NSString *)kGMSPlaceTypeBankExported;
		[Field ("kGMSPlaceTypeBank", "__Internal")]
		NSString Bank { get; }

		// -(NSString *)kGMSPlaceTypeBarExported;
		[Field ("kGMSPlaceTypeBar", "__Internal")]
		NSString Bar { get; }

		// -(NSString *)kGMSPlaceTypeBeautySalonExported;
		[Field ("kGMSPlaceTypeBeautySalon", "__Internal")]
		NSString BeautySalon { get; }

		// -(NSString *)kGMSPlaceTypeBicycleStoreExported;
		[Field ("kGMSPlaceTypeBicycleStore", "__Internal")]
		NSString BicycleStore { get; }

		// -(NSString *)kGMSPlaceTypeBookStoreExported;
		[Field ("kGMSPlaceTypeBookStore", "__Internal")]
		NSString BookStore { get; }

		// -(NSString *)kGMSPlaceTypeBowlingAlleyExported;
		[Field ("kGMSPlaceTypeBowlingAlley", "__Internal")]
		NSString BowlingAlley { get; }

		// -(NSString *)kGMSPlaceTypeBusStationExported;
		[Field ("kGMSPlaceTypeBusStation", "__Internal")]
		NSString BusStation { get; }

		// -(NSString *)kGMSPlaceTypeCafeExported;
		[Field ("kGMSPlaceTypeCafe", "__Internal")]
		NSString Cafe { get; }

		// -(NSString *)kGMSPlaceTypeCampgroundExported;
		[Field ("kGMSPlaceTypeCampground", "__Internal")]
		NSString Campground { get; }

		// -(NSString *)kGMSPlaceTypeCarDealerExported;
		[Field ("kGMSPlaceTypeCarDealer", "__Internal")]
		NSString CarDealer { get; }

		// -(NSString *)kGMSPlaceTypeCarRentalExported;
		[Field ("kGMSPlaceTypeCarRental", "__Internal")]
		NSString CarRental { get; }

		// -(NSString *)kGMSPlaceTypeCarRepairExported;
		[Field ("kGMSPlaceTypeCarRepair", "__Internal")]
		NSString CarRepair { get; }

		// -(NSString *)kGMSPlaceTypeCarWashExported;
		[Field ("kGMSPlaceTypeCarWash", "__Internal")]
		NSString CarWash { get; }

		// -(NSString *)kGMSPlaceTypeCasinoExported;
		[Field ("kGMSPlaceTypeCasino", "__Internal")]
		NSString Casino { get; }

		// -(NSString *)kGMSPlaceTypeCemeteryExported;
		[Field ("kGMSPlaceTypeCemetery", "__Internal")]
		NSString Cemetery { get; }

		// -(NSString *)kGMSPlaceTypeChurchExported;
		[Field ("kGMSPlaceTypeChurch", "__Internal")]
		NSString Church { get; }

		// -(NSString *)kGMSPlaceTypeCityHallExported;
		[Field ("kGMSPlaceTypeCityHall", "__Internal")]
		NSString CityHall { get; }

		// -(NSString *)kGMSPlaceTypeClothingStoreExported;
		[Field ("kGMSPlaceTypeClothingStore", "__Internal")]
		NSString ClothingStore { get; }

		// -(NSString *)kGMSPlaceTypeColloquialAreaExported;
		[Field ("kGMSPlaceTypeColloquialArea", "__Internal")]
		NSString ColloquialArea { get; }

		// -(NSString *)kGMSPlaceTypeConvenienceStoreExported;
		[Field ("kGMSPlaceTypeConvenienceStore", "__Internal")]
		NSString ConvenienceStore { get; }

		// -(NSString *)kGMSPlaceTypeCountryExported;
		[Field ("kGMSPlaceTypeCountry", "__Internal")]
		NSString Country { get; }

		// -(NSString *)kGMSPlaceTypeCourthouseExported;
		[Field ("kGMSPlaceTypeCourthouse", "__Internal")]
		NSString Courthouse { get; }

		// -(NSString *)kGMSPlaceTypeDentistExported;
		[Field ("kGMSPlaceTypeDentist", "__Internal")]
		NSString Dentist { get; }

		// -(NSString *)kGMSPlaceTypeDepartmentStoreExported;
		[Field ("kGMSPlaceTypeDepartmentStore", "__Internal")]
		NSString DepartmentStore { get; }

		// -(NSString *)kGMSPlaceTypeDoctorExported;
		[Field ("kGMSPlaceTypeDoctor", "__Internal")]
		NSString Doctor { get; }

		// -(NSString *)kGMSPlaceTypeElectricianExported;
		[Field ("kGMSPlaceTypeElectrician", "__Internal")]
		NSString Electrician { get; }

		// -(NSString *)kGMSPlaceTypeElectronicsStoreExported;
		[Field ("kGMSPlaceTypeElectronicsStore", "__Internal")]
		NSString ElectronicsStore { get; }

		// -(NSString *)kGMSPlaceTypeEmbassyExported;
		[Field ("kGMSPlaceTypeEmbassy", "__Internal")]
		NSString Embassy { get; }

		// -(NSString *)kGMSPlaceTypeEstablishmentExported;
		[Field ("kGMSPlaceTypeEstablishment", "__Internal")]
		NSString Establishment { get; }

		// -(NSString *)kGMSPlaceTypeFinanceExported;
		[Field ("kGMSPlaceTypeFinance", "__Internal")]
		NSString Finance { get; }

		// -(NSString *)kGMSPlaceTypeFireStationExported;
		[Field ("kGMSPlaceTypeFireStation", "__Internal")]
		NSString FireStation { get; }

		// -(NSString *)kGMSPlaceTypeFloorExported;
		[Field ("kGMSPlaceTypeFloor", "__Internal")]
		NSString Floor { get; }

		// -(NSString *)kGMSPlaceTypeFloristExported;
		[Field ("kGMSPlaceTypeFlorist", "__Internal")]
		NSString Florist { get; }

		// -(NSString *)kGMSPlaceTypeFoodExported;
		[Field ("kGMSPlaceTypeFood", "__Internal")]
		NSString Food { get; }

		// -(NSString *)kGMSPlaceTypeFuneralHomeExported;
		[Field ("kGMSPlaceTypeFuneralHome", "__Internal")]
		NSString FuneralHome { get; }

		// -(NSString *)kGMSPlaceTypeFurnitureStoreExported;
		[Field ("kGMSPlaceTypeFurnitureStore", "__Internal")]
		NSString FurnitureStore { get; }

		// -(NSString *)kGMSPlaceTypeGasStationExported;
		[Field ("kGMSPlaceTypeGasStation", "__Internal")]
		NSString GasStation { get; }

		// -(NSString *)kGMSPlaceTypeGeneralContractorExported;
		[Field ("kGMSPlaceTypeGeneralContractor", "__Internal")]
		NSString GeneralContractor { get; }

		// -(NSString *)kGMSPlaceTypeGeocodeExported;
		[Field ("kGMSPlaceTypeGeocode", "__Internal")]
		NSString Geocode { get; }

		// -(NSString *)kGMSPlaceTypeGroceryOrSupermarketExported;
		[Field ("kGMSPlaceTypeGroceryOrSupermarket", "__Internal")]
		NSString GroceryOrSupermarket { get; }

		// -(NSString *)kGMSPlaceTypeGymExported;
		[Field ("kGMSPlaceTypeGym", "__Internal")]
		NSString Gym { get; }

		// -(NSString *)kGMSPlaceTypeHairCareExported;
		[Field ("kGMSPlaceTypeHairCare", "__Internal")]
		NSString HairCare { get; }

		// -(NSString *)kGMSPlaceTypeHardwareStoreExported;
		[Field ("kGMSPlaceTypeHardwareStore", "__Internal")]
		NSString HardwareStore { get; }

		// -(NSString *)kGMSPlaceTypeHealthExported;
		[Field ("kGMSPlaceTypeHealth", "__Internal")]
		NSString Health { get; }

		// -(NSString *)kGMSPlaceTypeHinduTempleExported;
		[Field ("kGMSPlaceTypeHinduTemple", "__Internal")]
		NSString HinduTemple { get; }

		// -(NSString *)kGMSPlaceTypeHomeGoodsStoreExported;
		[Field ("kGMSPlaceTypeHomeGoodsStore", "__Internal")]
		NSString HomeGoodsStore { get; }

		// -(NSString *)kGMSPlaceTypeHospitalExported;
		[Field ("kGMSPlaceTypeHospital", "__Internal")]
		NSString Hospital { get; }

		// -(NSString *)kGMSPlaceTypeInsuranceAgencyExported;
		[Field ("kGMSPlaceTypeInsuranceAgency", "__Internal")]
		NSString InsuranceAgency { get; }

		// -(NSString *)kGMSPlaceTypeIntersectionExported;
		[Field ("kGMSPlaceTypeIntersection", "__Internal")]
		NSString Intersection { get; }

		// -(NSString *)kGMSPlaceTypeJewelryStoreExported;
		[Field ("kGMSPlaceTypeJewelryStore", "__Internal")]
		NSString JewelryStore { get; }

		// -(NSString *)kGMSPlaceTypeLaundryExported;
		[Field ("kGMSPlaceTypeLaundry", "__Internal")]
		NSString Laundry { get; }

		// -(NSString *)kGMSPlaceTypeLawyerExported;
		[Field ("kGMSPlaceTypeLawyer", "__Internal")]
		NSString Lawyer { get; }

		// -(NSString *)kGMSPlaceTypeLibraryExported;
		[Field ("kGMSPlaceTypeLibrary", "__Internal")]
		NSString Library { get; }

		// -(NSString *)kGMSPlaceTypeLiquorStoreExported;
		[Field ("kGMSPlaceTypeLiquorStore", "__Internal")]
		NSString LiquorStore { get; }

		// -(NSString *)kGMSPlaceTypeLocalGovernmentOfficeExported;
		[Field ("kGMSPlaceTypeLocalGovernmentOffice", "__Internal")]
		NSString LocalGovernmentOffice { get; }

		// -(NSString *)kGMSPlaceTypeLocalityExported;
		[Field ("kGMSPlaceTypeLocality", "__Internal")]
		NSString Locality { get; }

		// -(NSString *)kGMSPlaceTypeLocksmithExported;
		[Field ("kGMSPlaceTypeLocksmith", "__Internal")]
		NSString Locksmith { get; }

		// -(NSString *)kGMSPlaceTypeLodgingExported;
		[Field ("kGMSPlaceTypeLodging", "__Internal")]
		NSString Lodging { get; }

		// -(NSString *)kGMSPlaceTypeMealDeliveryExported;
		[Field ("kGMSPlaceTypeMealDelivery", "__Internal")]
		NSString MealDelivery { get; }

		// -(NSString *)kGMSPlaceTypeMealTakeawayExported;
		[Field ("kGMSPlaceTypeMealTakeaway", "__Internal")]
		NSString MealTakeaway { get; }

		// -(NSString *)kGMSPlaceTypeMosqueExported;
		[Field ("kGMSPlaceTypeMosque", "__Internal")]
		NSString Mosque { get; }

		// -(NSString *)kGMSPlaceTypeMovieRentalExported;
		[Field ("kGMSPlaceTypeMovieRental", "__Internal")]
		NSString MovieRental { get; }

		// -(NSString *)kGMSPlaceTypeMovieTheaterExported;
		[Field ("kGMSPlaceTypeMovieTheater", "__Internal")]
		NSString MovieTheater { get; }

		// -(NSString *)kGMSPlaceTypeMovingCompanyExported;
		[Field ("kGMSPlaceTypeMovingCompany", "__Internal")]
		NSString MovingCompany { get; }

		// -(NSString *)kGMSPlaceTypeMuseumExported;
		[Field ("kGMSPlaceTypeMuseum", "__Internal")]
		NSString Museum { get; }

		// -(NSString *)kGMSPlaceTypeNaturalFeatureExported;
		[Field ("kGMSPlaceTypeNaturalFeature", "__Internal")]
		NSString NaturalFeature { get; }

		// -(NSString *)kGMSPlaceTypeNeighborhoodExported;
		[Field ("kGMSPlaceTypeNeighborhood", "__Internal")]
		NSString Neighborhood { get; }

		// -(NSString *)kGMSPlaceTypeNightClubExported;
		[Field ("kGMSPlaceTypeNightClub", "__Internal")]
		NSString NightClub { get; }

		// -(NSString *)kGMSPlaceTypePainterExported;
		[Field ("kGMSPlaceTypePainter", "__Internal")]
		NSString Painter { get; }

		// -(NSString *)kGMSPlaceTypeParkExported;
		[Field ("kGMSPlaceTypePark", "__Internal")]
		NSString Park { get; }

		// -(NSString *)kGMSPlaceTypeParkingExported;
		[Field ("kGMSPlaceTypeParking", "__Internal")]
		NSString Parking { get; }

		// -(NSString *)kGMSPlaceTypePetStoreExported;
		[Field ("kGMSPlaceTypePetStore", "__Internal")]
		NSString PetStore { get; }

		// -(NSString *)kGMSPlaceTypePharmacyExported;
		[Field ("kGMSPlaceTypePharmacy", "__Internal")]
		NSString Pharmacy { get; }

		// -(NSString *)kGMSPlaceTypePhysiotherapistExported;
		[Field ("kGMSPlaceTypePhysiotherapist", "__Internal")]
		NSString Physiotherapist { get; }

		// -(NSString *)kGMSPlaceTypePlaceOfWorshipExported;
		[Field ("kGMSPlaceTypePlaceOfWorship", "__Internal")]
		NSString PlaceOfWorship { get; }

		// -(NSString *)kGMSPlaceTypePlumberExported;
		[Field ("kGMSPlaceTypePlumber", "__Internal")]
		NSString Plumber { get; }

		// -(NSString *)kGMSPlaceTypePointOfInterestExported;
		[Field ("kGMSPlaceTypePointOfInterest", "__Internal")]
		NSString PointOfInterest { get; }

		// -(NSString *)kGMSPlaceTypePoliceExported;
		[Field ("kGMSPlaceTypePolice", "__Internal")]
		NSString Police { get; }

		// -(NSString *)kGMSPlaceTypePoliticalExported;
		[Field ("kGMSPlaceTypePolitical", "__Internal")]
		NSString Political { get; }

		// -(NSString *)kGMSPlaceTypePostBoxExported;
		[Field ("kGMSPlaceTypePostBox", "__Internal")]
		NSString PostBox { get; }

		// -(NSString *)kGMSPlaceTypePostOfficeExported;
		[Field ("kGMSPlaceTypePostOffice", "__Internal")]
		NSString PostOffice { get; }

		// -(NSString *)kGMSPlaceTypePostalCodeExported;
		[Field ("kGMSPlaceTypePostalCode", "__Internal")]
		NSString PostalCode { get; }

		// -(NSString *)kGMSPlaceTypePostalCodePrefixExported;
		[Field ("kGMSPlaceTypePostalCodePrefix", "__Internal")]
		NSString PostalCodePrefix { get; }

		// -(NSString *)kGMSPlaceTypePostalTownExported;
		[Field ("kGMSPlaceTypePostalTown", "__Internal")]
		NSString PostalTown { get; }

		// -(NSString *)kGMSPlaceTypePremiseExported;
		[Field ("kGMSPlaceTypePremise", "__Internal")]
		NSString Premise { get; }

		// -(NSString *)kGMSPlaceTypeRealEstateAgencyExported;
		[Field ("kGMSPlaceTypeRealEstateAgency", "__Internal")]
		NSString RealEstateAgency { get; }

		// -(NSString *)kGMSPlaceTypeRestaurantExported;
		[Field ("kGMSPlaceTypeRestaurant", "__Internal")]
		NSString Restaurant { get; }

		// -(NSString *)kGMSPlaceTypeRoofingContractorExported;
		[Field ("kGMSPlaceTypeRoofingContractor", "__Internal")]
		NSString RoofingContractor { get; }

		// -(NSString *)kGMSPlaceTypeRoomExported;
		[Field ("kGMSPlaceTypeRoom", "__Internal")]
		NSString Room { get; }

		// -(NSString *)kGMSPlaceTypeRouteExported;
		[Field ("kGMSPlaceTypeRoute", "__Internal")]
		NSString Route { get; }

		// -(NSString *)kGMSPlaceTypeRvParkExported;
		[Field ("kGMSPlaceTypeRvPark", "__Internal")]
		NSString RvPark { get; }

		// -(NSString *)kGMSPlaceTypeSchoolExported;
		[Field ("kGMSPlaceTypeSchool", "__Internal")]
		NSString School { get; }

		// -(NSString *)kGMSPlaceTypeShoeStoreExported;
		[Field ("kGMSPlaceTypeShoeStore", "__Internal")]
		NSString ShoeStore { get; }

		// -(NSString *)kGMSPlaceTypeShoppingMallExported;
		[Field ("kGMSPlaceTypeShoppingMall", "__Internal")]
		NSString ShoppingMall { get; }

		// -(NSString *)kGMSPlaceTypeSpaExported;
		[Field ("kGMSPlaceTypeSpa", "__Internal")]
		NSString Spa { get; }

		// -(NSString *)kGMSPlaceTypeStadiumExported;
		[Field ("kGMSPlaceTypeStadium", "__Internal")]
		NSString Stadium { get; }

		// -(NSString *)kGMSPlaceTypeStorageExported;
		[Field ("kGMSPlaceTypeStorage", "__Internal")]
		NSString Storage { get; }

		// -(NSString *)kGMSPlaceTypeStoreExported;
		[Field ("kGMSPlaceTypeStore", "__Internal")]
		NSString Store { get; }

		// -(NSString *)kGMSPlaceTypeStreetAddressExported;
		[Field ("kGMSPlaceTypeStreetAddress", "__Internal")]
		NSString StreetAddress { get; }

		// -(NSString *)kGMSPlaceTypeSublocalityExported;
		[Field ("kGMSPlaceTypeSublocality", "__Internal")]
		NSString Sublocality { get; }

		// -(NSString *)kGMSPlaceTypeSublocalityLevel1Exported;
		[Field ("kGMSPlaceTypeSublocalityLevel1", "__Internal")]
		NSString SublocalityLevel1 { get; }

		// -(NSString *)kGMSPlaceTypeSublocalityLevel2Exported;
		[Field ("kGMSPlaceTypeSublocalityLevel2", "__Internal")]
		NSString SublocalityLevel2 { get; }

		// -(NSString *)kGMSPlaceTypeSublocalityLevel3Exported;
		[Field ("kGMSPlaceTypeSublocalityLevel3", "__Internal")]
		NSString SublocalityLevel3 { get; }

		// -(NSString *)kGMSPlaceTypeSublocalityLevel4Exported;
		[Field ("kGMSPlaceTypeSublocalityLevel4", "__Internal")]
		NSString SublocalityLevel4 { get; }

		// -(NSString *)kGMSPlaceTypeSublocalityLevel5Exported;
		[Field ("kGMSPlaceTypeSublocalityLevel5", "__Internal")]
		NSString SublocalityLevel5 { get; }

		// -(NSString *)kGMSPlaceTypeSubpremiseExported;
		[Field ("kGMSPlaceTypeSubpremise", "__Internal")]
		NSString Subpremise { get; }

		// -(NSString *)kGMSPlaceTypeSubwayStationExported;
		[Field ("kGMSPlaceTypeSubwayStation", "__Internal")]
		NSString SubwayStation { get; }

		// -(NSString *)kGMSPlaceTypeSynagogueExported;
		[Field ("kGMSPlaceTypeSynagogue", "__Internal")]
		NSString Synagogue { get; }

		// -(NSString *)kGMSPlaceTypeTaxiStandExported;
		[Field ("kGMSPlaceTypeTaxiStand", "__Internal")]
		NSString TaxiStand { get; }

		// -(NSString *)kGMSPlaceTypeTrainStationExported;
		[Field ("kGMSPlaceTypeTrainStation", "__Internal")]
		NSString TrainStation { get; }

		// -(NSString *)kGMSPlaceTypeTransitStationExported;
		[Field ("kGMSPlaceTypeTransitStation", "__Internal")]
		NSString TransitStation { get; }

		// -(NSString *)kGMSPlaceTypeTravelAgencyExported;
		[Field ("kGMSPlaceTypeTravelAgency", "__Internal")]
		NSString TravelAgency { get; }

		// -(NSString *)kGMSPlaceTypeUniversityExported;
		[Field ("kGMSPlaceTypeUniversity", "__Internal")]
		NSString University { get; }

		// -(NSString *)kGMSPlaceTypeVeterinaryCareExported;
		[Field ("kGMSPlaceTypeVeterinaryCare", "__Internal")]
		NSString VeterinaryCare { get; }

		// -(NSString *)kGMSPlaceTypeZooExported;
		[Field ("kGMSPlaceTypeZoo", "__Internal")]
		NSString Zoo { get; }
	}

	// @interface GMSUserAddedPlace : NSObject
	[Obsolete ("The Add Place feature is deprecated as of June 30, 2017. This feature will be turned down on June 30, 2018, and will no longer be available after that date.")]
	[BaseType (typeof (NSObject), Name = "GMSUserAddedPlace")]
	interface UserAddedPlace
	{
		// @property (copy, nonatomic) NSString * name;
		[NullAllowed]
		[Export ("name", ArgumentSemantic.Copy)]
		string Name { get; set; }

		// @property (copy, nonatomic) NSString * address;
		[NullAllowed]
		[Export ("address", ArgumentSemantic.Copy)]
		string Address { get; set; }

		// @property (assign, nonatomic) CLLocationCoordinate2D coordinate;
		[Export ("coordinate", ArgumentSemantic.Assign)]
		CLLocationCoordinate2D Coordinate { get; set; }

		// @property (copy, nonatomic) NSString * phoneNumber;
		[NullAllowed]
		[Export ("phoneNumber", ArgumentSemantic.Copy)]
		string PhoneNumber { get; set; }

		// @property (copy, nonatomic) NSArray * types;
		[NullAllowed]
		[Export ("types", ArgumentSemantic.Copy)]
		string [] Types { get; set; }

		// @property (copy, nonatomic) NSString * website;
		[NullAllowed]
		[Export ("website", ArgumentSemantic.Copy)]
		string Website { get; set; }
	}
}

namespace Google.Places.Picker
{
	// @interface GMSPlacePicker : NSObject
	[Obsolete ("Use PlacePickerViewController class instead.")]
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSPlacePicker")]
	interface PlacePicker
	{
		// @property (readonly, copy, nonatomic) GMSPlacePickerConfig * config;
		[Export ("config", ArgumentSemantic.Copy)]
		PlacePickerConfig Config { get; }

		// -(instancetype)initWithConfig:(GMSPlacePickerConfig *)config;
		[Export ("initWithConfig:")]
		IntPtr Constructor (PlacePickerConfig config);

		// -(void)pickPlaceWithCallback:(GMSPlaceResultCallback)callback;
		[Export ("pickPlaceWithCallback:")]
		void PickPlace (Google.Places.PlaceResultHandler callback);
	}

	// @interface GMSPlacePickerConfig : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "GMSPlacePickerConfig")]
	interface PlacePickerConfig
	{
		// @property (readonly, nonatomic, strong) GMSCoordinateBounds * viewport;
		[NullAllowed]
		[Export ("viewport", ArgumentSemantic.Strong)]
		Google.Maps.CoordinateBounds Viewport { get; }

		// -(instancetype)initWithViewport:(GMSCoordinateBounds *)viewport;
		[Export ("initWithViewport:")]
		IntPtr Constructor ([NullAllowed] Google.Maps.CoordinateBounds viewport);
	}

	interface IPlacePickerViewControllerDelegate { }

	// @protocol GMSPlacePickerViewControllerDelegate <NSObject>
	[Model]
	[Protocol]
	[BaseType (typeof (NSObject), Name = "GMSPlacePickerViewControllerDelegate")]
	interface PlacePickerViewControllerDelegate
	{
		// @required -(void)placePicker:(GMSPlacePickerViewController * _Nonnull)viewController didPickPlace:(GMSPlace * _Nonnull)place;
		[Abstract]
		[EventArgs ("PlacePickerViewControllerPlacePicked")]
		[EventName ("PlacePicked")]
		[Export ("placePicker:didPickPlace:")]
		void DidPickPlace (PlacePickerViewController viewController, Google.Places.Place place);

		// @optional -(void)placePicker:(GMSPlacePickerViewController * _Nonnull)viewController didFailWithError:(NSError * _Nonnull)error;
		[EventArgs ("PlacePickerViewControllerFailed")]
		[EventName ("Failed")]
		[Export ("placePicker:didFailWithError:")]
		void DidFail (PlacePickerViewController viewController, NSError error);

		// @optional -(void)placePickerDidCancel:(GMSPlacePickerViewController * _Nonnull)viewController;
		[EventArgs ("PlacePickerViewControllerCanceled")]
		[EventName ("Canceled")]
		[Export ("placePickerDidCancel:")]
		void DidCancel (PlacePickerViewController viewController);
	}

	// @interface GMSPlacePickerViewController : UIViewController
	[DisableDefaultCtor]
	[BaseType (typeof (UIViewController),
		   Name = "GMSPlacePickerViewController",
		   Delegates = new string [] { "Delegate" },
	           Events = new Type [] { typeof (PlacePickerViewControllerDelegate) })]
	interface PlacePickerViewController
	{
		// @property (nonatomic, weak) id<GMSPlacePickerViewControllerDelegate> _Nullable delegate __attribute__((iboutlet));
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IPlacePickerViewControllerDelegate Delegate { get; set; }

		// -(instancetype _Nonnull)initWithConfig:(GMSPlacePickerConfig * _Nonnull)config;
		[Export ("initWithConfig:")]
		IntPtr Constructor (PlacePickerConfig config);
	}
}
