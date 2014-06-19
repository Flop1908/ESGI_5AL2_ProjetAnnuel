//
//  AnneProductViewCell.h
//  Anne&DocTique2
//
//  Created by Kapi on 28/05/2014.
//  Copyright (c) 2014 Lionel. All rights reserved.
//


#import <UIKit/UIKit.h>
@class AnneProduct;

@interface AnneProductViewCell : UICollectionViewCell

@property (strong, nonatomic) AnneProduct *product;

// These methods let you customize the names of the UIImage instances
// used for the default icon and failed icon. The default icon is used
// until the specified image has been loaded, and the failed icon is
// used in case the specified image can't be loaded
+ (void)setDefaultIconName:(NSString *)name;
+ (void)setFailedIconName:(NSString *)name;

@end
